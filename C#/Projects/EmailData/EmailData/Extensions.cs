using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmailData
{
  public static class Extensions
  {
    public static string ActionTag(this object o)
    {
      if (o == null) return "";

      var pi = o.GetType().GetProperty("Tag");
      if (pi == null) return "";
      return pi.GetValue(o)?.ToString() ?? "";
    }

    [DebuggerStepThrough]
    public static bool IsBlank(this string s) => s is null || s.Trim().Length == 0;

    [DebuggerStepThrough]
    public static bool IsNotBlank(this string s) => !s.IsBlank();

    public static DateTime ToDateTime(this string s)
    {
      return new DateTime(
        Convert.ToInt32(s.Substring(0, 4)),
        Convert.ToInt32(s.Substring(4, 2)),
        Convert.ToInt32(s.Substring(6, 2)),
        Convert.ToInt32(s.Substring(9, 2)),
        Convert.ToInt32(s.Substring(11, 2)),
        Convert.ToInt32(s.Substring(13, 2))
      );
    }

    public static string ToSqlDate(this DateTime dt)
    {
      return dt.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static string ToSqlString(this string s)
    {
      if (s == null || s.Trim().Length == 0) return "";
      return s.Replace("'", "''");
    }


    [DebuggerStepThrough]
    public static DateTime? DbToDateTime(this object value)
    {
      if (value == null || value == DBNull.Value)
        return (DateTime?)null;

      return Convert.ToDateTime(value);
    }

    [DebuggerStepThrough]
    public static string DbToString(this object value)
    {
      if (value == null || value == DBNull.Value)
        return null;

      return value.ToString();
    }

    [DebuggerStepThrough]
    public static int? DbToInt32(this object value)
    {
      if (value == null || value == DBNull.Value)
        return (int?)null;

      return Convert.ToInt32(value);
    }

    [DebuggerStepThrough]
    public static void SetInitialSizeAndLocation(this System.Windows.Forms.Form f, int horizontalSize = 0, int verticalSize = 0)
    {
      if (horizontalSize == 0)
        horizontalSize = 80;

      if (verticalSize == 0)
        verticalSize = 80;


      f.Size = new Size(Screen.PrimaryScreen.Bounds.Width * horizontalSize / 100,
                           Screen.PrimaryScreen.Bounds.Height * verticalSize / 100);
      f.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - f.Width / 2,
                                Screen.PrimaryScreen.Bounds.Height / 2 - f.Height / 2);
    }

    [DebuggerStepThrough]
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

      sb.Append("Exception Message Summary:" + g.crlf);
      for (int i = messageList.Count - 1; i > -1; i--)
      {
        sb.Append("[" + i.ToString("00") + "] " + messageList.ElementAt(i) + g.crlf);
      }

      sb.Append(g.crlf);

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
              typeLoadMessage += g.crlf;
              typeLoadMessage += "[" + typeLoadIndex.ToString() + "] " + lx.ToString();
              typeLoadIndex++;
            }
          }

          if (typeLoadMessage.IsNotBlank())
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

    [DebuggerStepThrough]
    public static bool IsNumeric(this string value)
    {
      if (value == null)
        return false;

      if (value.Trim().Length == 0)
        return false;

      foreach (Char c in value.Trim())
        if (!Char.IsNumber(c))
          return false;

      return true;
    }

    [DebuggerStepThrough]
    public static bool IsNotNumeric(this string value)
    {
      return !value.IsNumeric();
    }
  }
}
