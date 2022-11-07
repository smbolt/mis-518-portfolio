using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using o = Microsoft.Office.Interop.Outlook;

namespace OutlookPstParser
{
  class Program
  {
    private static string _emailPath = @"C:\_work\Email_Export";
    private static string crlf = Environment.NewLine;

    private static DateTime _cutoffDate = new DateTime(2022, 05, 28);

    static void Main(string[] args)
    {
      o.ApplicationClass app = new o.ApplicationClass();
      o.NameSpace ns = null;
      o.MAPIFolder inbox = null;
      o.Items mailItems = null;

      try
      {
        Console.WriteLine("OutlookPstParser Starting...");

        ns = app.GetNamespace("MAPI");
        inbox = ns.GetDefaultFolder(o.OlDefaultFolders.olFolderInbox);

        DateTime filterDate = _cutoffDate;
        string filterDateString = filterDate.Day + "/" + filterDate.Month + "/" + filterDate.Year + " 1:00am";
        string filter = "[CreationTime] > '" + string.Format(filterDateString, "ddddd h:nn AMPM") + "'";

        mailItems = inbox.Items.Restrict(filter);

        var sb = new System.Text.StringBuilder();

        foreach (var mailItem in mailItems)
        {
          var email = mailItem as o.MailItem;
          if (email == null) continue;
          try
          {
            if (email.SenderEmailAddress?.ToLower() == "sbolt@adsdi.com")
            {
              var sentDt = email.SentOn.ToString("yyyyMMdd-HHmmss");

              if (email.SentOn < _cutoffDate)
              {
                Console.WriteLine(sentDt);
                continue;
              }

              sb.Append($"{sentDt}  {email.Subject?.Trim() ?? "NO-SUBJECT"}{crlf}");

              var uniqueId = email.ConversationID;
              var fileName = $"{sentDt}-{uniqueId}.xml";
              if (File.Exists($@"{_emailPath}/{fileName}"))
              {
                Console.WriteLine($"{fileName} already written");
                continue;
              }
              var xmlEmail = new XElement("Email");
              xmlEmail.Add(new XAttribute("Source", "2"));
              xmlEmail.Add(new XAttribute("Sent", sentDt));
              xmlEmail.Add(new XAttribute("FromName", email.Sender.Name));
              xmlEmail.Add(new XAttribute("FromAddress", email.SenderEmailAddress));
              xmlEmail.Add(new XAttribute("ToName", email.To));
              xmlEmail.Add(new XAttribute("ToAddress", "sbolt@adsdi.com"));
              xmlEmail.Add(new XElement("Subject", email.Subject?.Trim() ?? ""));
              xmlEmail.Add(new XElement("Body", email.Body.Trim()));


              var subject = email.Subject?.ToString() ?? "";
              WriteTextFile(email.Body.Trim());

              var xml = xmlEmail.ToString();
              Console.WriteLine(fileName);
              File.WriteAllText($@"{_emailPath}/{fileName}", xml);
            }
            Marshal.ReleaseComObject(email);
          }
          catch (Exception ex)
          {
            Console.Write($"*** Exception occurred: {ex.Message}");
          }
        }

        var report = sb.ToString();
        Console.WriteLine(report);

        Console.WriteLine("OutlookPstParser Ending");
        Console.WriteLine("Press any key to terminate");
        Console.Read();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An exception has occurred while attempting to process the Outlook PST file.{crlf}{ex.ToReport()}");
        Console.WriteLine("Press any key to terminate");
        Console.Read();
      }
      finally
      {
        ReleaseComObject(mailItems);
        ReleaseComObject(inbox);
        ReleaseComObject(ns);
        ReleaseComObject(app);
      }
    }

    private static void WriteTextFile(string body)
    {
      if (body.Contains("ProcessEraFiles") || body.Contains("PreprocessEraFiles"))
      {
        File.AppendAllText($@"{_emailPath}/EraFiles.txt", body);
      }
    }

    private static void ReleaseComObject(object obj)
    {
      if (obj != null)
      {
        Marshal.ReleaseComObject(obj);
        obj = null;
      }
    }
  }
}
