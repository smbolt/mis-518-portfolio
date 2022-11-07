using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OutlookPstParser
{
  public static class Extensions
  {
    private static string crlf = Environment.NewLine;

    public static string ToReport(this Exception value)
    {
      StringBuilder sb = new StringBuilder();

      Exception ex = value;
      bool moreExceptions = true;
      int level = 0;

      var messageList = new List<string>();
      Exception ex2 = ex;
      string msg = ex.Message;
      if (ex2.GetType().Name == "ReflectionTypeLoadException")
        msg += " [SEE TYPE LOAD EXCEPTION DETAIL BELOW]";

      messageList.Add(msg);
      while (ex2.InnerException != null)
      {
        ex2 = ex2.InnerException;
        msg = ex2.Message;
        if (ex2.GetType().Name == "ReflectionTypeLoadException")
          msg += " [SEE TYPE LOAD EXCEPTION DETAIL BELOW]";

        messageList.Add(msg);
      }

      sb.Append("Exception Message Summary:" + crlf);
      for (int i = messageList.Count - 1; i > -1; i--)
      {
        sb.Append("[" + i.ToString("00") + "] " + messageList.ElementAt(i) + crlf);
      }

      sb.Append(crlf);

      while (moreExceptions)
      {
        if (ex.Message.StartsWith("!"))
          return ex.Message.Substring(1);

        string message = ex.Message;

        if (ex.GetType().Name == "ReflectionTypeLoadException")
        {
          string typeLoadMessage = "*** REFLECTION TYPE LOAD EXCEPTION ***";
          var typeLoadException = (ReflectionTypeLoadException)ex;
          if (typeLoadException.LoaderExceptions.Length > 0)
          {
            int typeLoadIndex = 0;
            foreach (var lx in typeLoadException.LoaderExceptions)
            {
              typeLoadMessage += crlf;
              typeLoadMessage += "[" + typeLoadIndex.ToString() + "] " + lx.ToString();
              typeLoadIndex++;
            }
          }

          if (!String.IsNullOrEmpty(typeLoadMessage))
            message = typeLoadMessage;
        }

        sb.Append("Level:" + level.ToString() + " Type=" + ex.GetType().ToString() + Environment.NewLine +
                  "Message: " + message + Environment.NewLine +
                  "StackTrace:" + ex.StackTrace + Environment.NewLine);

        if (ex.InnerException == null)
          moreExceptions = false;
        else
        {
          sb.Append(Environment.NewLine);
          ex = ex.InnerException;
          level++;
        }
      }

      string report = sb.ToString();
      return report;
    }
  }
}
