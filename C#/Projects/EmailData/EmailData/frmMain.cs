using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace EmailData
{
  public partial class frmMain : Form
  {
    private string _emailFolder = @"C:\_work\Email_Export";
    private string _connectionString = @"Server=WIN2019SE1,5555;Database=EmailData;User Id=sa;Password=gen126@Adsdi;";
    private Dictionary<string, int> _functionSet;

    public frmMain()
    {
      InitializeComponent();
      InitializeForm();
    }

    private void Action(object sender, EventArgs e)
    {
      var action = sender.ActionTag();
      switch (action)
      {
        case "LoadRawEmails":
          LoadRawEmails();
          break;

        case "ProcessRawEmails":
          ProcessRawEmails();
          break;

        case "GetUnits":
          GetUnits();
          break;

        case "ViewFunction":
          ViewFunction();
          break;

        case "ExtractCsv":
          ExtractCsv();
          break;

        case "ExtractCsv2":
          ExtractCsv2();
          break;
          break;

        case "ExtractCsv3":
          ExtractCsv3();
          break;

        case "Exit":
          this.Close();
          break;
      }
    }

    private void GetUnits()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;

        var functionId = _functionSet[cboFunctions.Text];
        var sb = new StringBuilder();

        var sql =
          $"SELECT Id, Body {g.crlf}" +
          $"FROM EmailRaw{g.crlf}" +
          $"WHERE FunctionId = {functionId}{g.crlf}" + 
          $"ORDER BY DateSent";

        var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd =  new SqlCommand(sql, conn);
        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        da.Fill(ds);

        foreach (DataRow r in ds.Tables[0].Rows)
        {
          var id = r["Id"].DbToInt32().Value;
          var body = r["Body"].ToString();

          var lines = body.Split(Constants.NewLineCharacter).ToList();

          switch (cboFunctions.Text)
          {
            case "ProcessClaims":
              foreach (var line in lines)
              {
                var ln = line.Trim();

                if (ln.Contains("TOTAL CLAIMS IN BATCH"))
                {
                  var pos = ln.IndexOf(":");
                  if (pos > -1)
                  {
                    var units = ln.Substring(pos + 1).Trim();
                    if (units.IsNumeric())
                    {
                      sql =
                        $"UPDATE EmailRaw {g.crlf}" +
                        $"  SET Units = {units}{g.crlf}" +
                        $"  WHERE Id = {id}";
                      try
                      {
                        cmd.CommandText = sql;
                        var rows = cmd.ExecuteNonQuery();
                        var nUnits = Convert.ToInt32(units);
                        rtxtOut.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        lblStatus.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        Application.DoEvents();
                      }
                      catch
                      {
                        throw;
                      }
                    }
                  }
                  break;
                }
              }
              break;

            case "UploadFiles":
              foreach (var line in lines)
              {
                var ln = line.Trim();

                if (ln.Contains("Local Files Uploaded"))
                {
                  var pos = ln.IndexOf(":");
                  if (pos > -1)
                  {
                    var units = ln.Substring(pos + 1).Trim();
                    if (units.IsNumeric())
                    {
                      sql =
                        $"UPDATE EmailRaw {g.crlf}" +
                        $"  SET Units = {units}{g.crlf}" +
                        $"  WHERE Id = {id}";
                      try
                      {
                        cmd.CommandText = sql;
                        var rows = cmd.ExecuteNonQuery();
                        var nUnits = Convert.ToInt32(units);
                        rtxtOut.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        lblStatus.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        Application.DoEvents();
                      }
                      catch
                      {
                        throw;
                      }
                    }
                  }
                  break;
                }
              }
              break;

            case "DownloadFiles":
              foreach (var line in lines)
              {
                var ln = line.Trim();

                if (ln.Contains("Remote Files Downloaded"))
                {
                  var pos = ln.IndexOf(":");
                  if (pos > -1)
                  {
                    var units = ln.Substring(pos + 1).Trim();
                    if (units.IsNumeric())
                    {
                      sql =
                        $"UPDATE EmailRaw {g.crlf}" +
                        $"  SET Units = {units}{g.crlf}" +
                        $"  WHERE Id = {id}";
                      try
                      {
                        cmd.CommandText = sql;
                        var rows = cmd.ExecuteNonQuery();
                        var nUnits = Convert.ToInt32(units);
                        rtxtOut.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        lblStatus.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        Application.DoEvents();
                      }
                      catch
                      {
                        throw;
                      }
                    }
                  }
                  break;
                }
              }
              break;

            case "PreprocessClaimResponseFiles":
            case "ProcessClaimResponseFiles":
            case "PreprocessEraFiles":
            case "ProcessEraFiles":
              foreach (var line in lines)
              {
                var ln = line.Trim();

                if (ln.Contains("Files Processed"))
                {
                  var pos = ln.IndexOf(":");
                  if (pos > -1)
                  {
                    var units = ln.Substring(pos + 1).Trim();
                    if (units.IsNumeric())
                    {
                      sql =
                        $"UPDATE EmailRaw {g.crlf}" +
                        $"  SET Units = {units}{g.crlf}" +
                        $"  WHERE Id = {id}";
                      try
                      {
                        cmd.CommandText = sql;
                        var rows = cmd.ExecuteNonQuery();
                        var nUnits = Convert.ToInt32(units);
                        rtxtOut.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        lblStatus.Text = $"Updated units to {nUnits.ToString("00000")} for Id {id.ToString("00000")}";
                        Application.DoEvents();
                      }
                      catch
                      {
                        throw;
                      }
                    }
                  }
                  break;
                }
              }
              break;
          }
        }

        rtxtOut.Text = "Processing complete.";

        conn.Close();
        conn.Dispose();

        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        this.Cursor = Cursors.Default;
        rtxtOut.Text = $"An error occurred while running the ProcessRawEmails method.{g.crlf}{ex.ToReport()}";
      }
    }

    private void ExtractCsv()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;

        var sb = new StringBuilder();

        var sql =
          $"SELECT Id, StartDateTime, FunctionId, DurationMilliseconds, Units{g.crlf}" +
          $"FROM EmailRaw{g.crlf}" +
          $"WHERE FunctionID < 50{g.crlf}" +
          $"  AND DurationMilliseconds > 0{g.crlf}" +
          $"  AND Units > 0{g.crlf}" +
          $"ORDER BY FunctionId, StartDateTime";

        var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand(sql, conn);
        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        da.Fill(ds);

        foreach (DataRow r in ds.Tables[0].Rows)
        {
          var id = r["Id"].DbToInt32().Value;
          var startDate = r["StartDateTime"].DbToDateTime().Value;
          var functionId = r["FunctionId"].DbToInt32().Value;
          var duration = r["DurationMilliseconds"].DbToInt32().Value;
          var units = r["Units"].DbToInt32().Value;

          var csv = $"{id},{functionId},{startDate.ToString("yyyy-MM-dd HH:mm:ss")},{units},{duration}";
          sb.Append($"{csv}{g.crlf}");
          rtxtOut.Text = csv;

          Application.DoEvents();
        }

        conn.Close();
        conn.Dispose();

        var csvFile = sb.ToString();
        rtxtOut.Text = csvFile;

        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        this.Cursor = Cursors.Default;
        rtxtOut.Text = $"An error occurred while running the ExtractCsv method.{g.crlf}{ex.ToReport()}";
      }
    }

    private void ExtractCsv2()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;

        var intervals = new SortedList<int, float>();
        var dtLimit = new DateTime(2022, 7, 1, 0, 0, 0);
        var dt = new DateTime(2021, 1, 1, 0, 0, 0);

        while (dt < dtLimit)
        {
          var intervalId = dt.Year * 1000000 +
                           dt.Month * 10000 +
                           dt.Day * 100 +
                           dt.Hour;
          intervals.Add(intervalId, 0.0F);
          dt = dt.AddHours(1);
        }

        var sb = new StringBuilder();

        var sql =
          $"SELECT StartDateTime, DurationMilliseconds{g.crlf}" +
          $"FROM EmailData.dbo.EmailRaw{g.crlf}" +
          $"WHERE StartDateTime BETWEEN '2021-01-01 00:00:00' AND '2022-06-30 23:59:59'{g.crlf}" +
          $"AND DurationMilliseconds > 999{g.crlf}" +
          $"AND ErrorOccurred = 0{g.crlf}" +
          $"AND FunctionId IN(1, 2, 3, 4, 5, 6, 7, 50, 62){g.crlf}" +
          $"ORDER BY StartDateTime";

        var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand(sql, conn);
        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        da.Fill(ds);

        foreach (DataRow r in ds.Tables[0].Rows)
        {
          var startDate = r["StartDateTime"].DbToDateTime().Value;
          var duration = r["DurationMilliseconds"].DbToInt32().Value;

          float intervalPct = duration / 3600000.0F ;

          var intervalId = startDate.Year * 1000000 +
                           startDate.Month * 10000 +
                           startDate.Day * 100 +
                           startDate.Hour;

          intervals[intervalId] += intervalPct;

          lblStatus.Text = $"{intervalId}:{intervalPct.ToString("##0.0000")}";
          Application.DoEvents();
        }

        conn.Close();
        conn.Dispose();

        sb.Append($"ID,Period_ID,Consumed{g.crlf}");

        var seq = 0;

        foreach (var interval in intervals)
        {
          var consumed = Convert.ToInt32(interval.Value * 1000);
          sb.Append($"{++seq},{interval.Key},{consumed}{g.crlf}");
        }

        var csvFile = sb.ToString();
        rtxtOut.Text = csvFile;

        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        this.Cursor = Cursors.Default;
        rtxtOut.Text = $"An error occurred while running the ExtractCsv method.{g.crlf}{ex.ToReport()}";
      }
    }

    private void ExtractCsv3()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;

        var sb = new StringBuilder();
        sb.Append($"ID,Period_ID,Consumed{g.crlf}");

        var hourlyCsv = File.ReadAllText(@"C:\_work\Interval_Consumption.csv");
        var hourlyLines = hourlyCsv.Split(Constants.NewLineDelimiter).ToList();  

        var intervals = new SortedList<int, float>();

        foreach (var line in hourlyLines)
        {
          var l = line.Trim();
          if (l.Length == 0) continue;
          var tokens = l.Split(Constants.CommaDelimiter);
          if (tokens[0] == "ID") continue;

          var dateToken = Convert.ToInt32(tokens[1].Substring(0, 6));
          var count = Convert.ToInt32(tokens[2]);
          
          if (!intervals.ContainsKey(dateToken))
            intervals.Add(dateToken, 0); 
          intervals[dateToken] += count;
        }

        var seq = 0;

        foreach (var interval in intervals)
        {
          sb.Append($"{++seq},{interval.Key},{interval.Value}{g.crlf}");
        }

        var csvFile = sb.ToString();
        rtxtOut.Text = csvFile;

        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        this.Cursor = Cursors.Default;
        rtxtOut.Text = $"An error occurred while running the ExtractCsv method.{g.crlf}{ex.ToReport()}";
      }
    }

    private void ViewFunction()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;

        var functionId = _functionSet[cboFunctions.Text];
        var sb = new StringBuilder();

        var sql =
          $"SELECT Id, Body {g.crlf}" +
          $"FROM EmailRaw{g.crlf}" +
          $"WHERE FunctionId = {functionId}{g.crlf}" +
          $"ORDER BY DateSent";

        var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand(sql, conn);
        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        da.Fill(ds);

        foreach (DataRow r in ds.Tables[0].Rows)
        {
          var id = r["Id"].DbToInt32().Value;
          var body = r["Body"].ToString();

          rtxtOut.Text = body;
          Application.DoEvents();
        }

        conn.Close();
        conn.Dispose();

        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        this.Cursor = Cursors.Default;
        rtxtOut.Text = $"An error occurred while running the ViewFUnction method.{g.crlf}{ex.ToReport()}";
      }
    }

    private void ProcessRawEmails()
    {
      try
      {
        rtxtOut.Text = "";
        Application.DoEvents();

        this.Cursor = Cursors.WaitCursor;
        var sb = new StringBuilder();
        var functions = new List<string>();

        var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand("", conn);

        var top = !ckGetAllRawEmails.Checked ? " TOP 2000 " : " ";

        var sql =
          $"SELECT{top}Id, DateSent, Subject, Body {g.crlf}" +
          $"FROM EmailRaw{g.crlf}" +
          $"ORDER BY DateSent";

        cmd.CommandText = sql;
        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        da.Fill(ds);

        foreach (DataRow r in ds.Tables[0].Rows)
        {
          var id = r["Id"].DbToInt32().Value;
          var dateSent = r["DateSent"].DbToDateTime().Value;
          var subject = r["Subject"].ToString();
          var body = r["Body"].ToString();

          var emailDataUpdated = false;

          var lines = body.Split(Constants.NewLineCharacter).ToList();

          var functionId = 0;
          var function = "";
          var originalFunction = "";
          DateTime? startDateTime = null;
          DateTime? endDateTime = null;
          var errorOccurred = false;

          if (body.Contains("An exception occurred")) errorOccurred = true; 

          foreach (var line in lines)
          {
            var ln = line.Trim();
            if (ln.StartsWith("Request Name"))
            {
              var pos = ln.IndexOf(":");
              if (pos == -1)
              {
                sb.Append($"Can't find semicolon in line {ln}{g.crlf}");
                continue;
              }

              function = ln.Substring(pos + 1).Trim();
              originalFunction = function;

              if (function == "ProcessClaims_Queue") functionId = 1;
              if (function == "ProcessClaims_Timer") functionId = 1;
              if (function == "ProcessClaims") functionId = 1;

              if (function == "UploadFiles") functionId = 2;
              if (function == "DownloadFiles") functionId = 3;

              if (function == "PreprocessFiles") functionId = 4;
              if (function == "PreprocessClaimResponseFiles") functionId = 4;
              if (function == "RunBatchManifest") functionId = 5;
              if (function == "ProcessClaimResponseFiles") functionId = 5;
              if (function == "ProcessClaimResponseFile") functionId = 5;

              if (function == "PreprocessEraFiles") functionId = 6;
              if (function == "ProcessEraFiles") functionId = 7;

              if (function == "ProcessPayments") functionId = 50;
              if (function == "TestFunctionTimeOut") functionId = 51;
              if (function == "InspectEnvironment") functionId = 52;
              if (function == "NormalizeClinicViewFolderNames") functionId = 53;
              if (function == "SendEraViaEmailAttachment") functionId = 54;
              if (function == "SendEraByGmail") functionId = 55;
              if (function == "CreateSecondaryClaimsReport") functionId = 56;
              if (function == "ReprocessEraFile") functionId = 57;
              if (function == "CorrectEraPosting") functionId = 58;
              if (function == "LoadErasToDatabase") functionId = 59;
              if (function == "ManageSqlLite") functionId = 60;
              if (function == "ManageAzureTableStorage") functionId = 61;
              if (function == "RetryEraFileErrors") functionId = 62;

              if (functionId == 0)
              {


              }

              if (function == "ProcessClaims_Queue" || function == "ProcessClaims_Timer")
                function = "ProcessClaims";

              if (function == "PreprocessFiles")
                function = "PreprocessClaimResponseFiles";

              if (function == "RunBatchManifest")
                function = "ProcessClaimResponseFiles";

              if (!functions.Contains(function)) functions.Add(function);

              continue;
            }

            if (ln.StartsWith("Started..."))
            {
              var pos = ln.IndexOf(":");
              if (pos > -1)
              {
                var dt = ln.Substring(pos + 1).Trim();
                if (!dt.ToLower().Contains("null"))
                {
                  try
                  {
                    startDateTime = DateTime.Parse(dt);
                  }
                  catch
                  {
                  }
                }
                continue;
              }
            }

            if (ln.StartsWith("Ended..."))
            {
              var pos = ln.IndexOf(":");
              if (pos > -1)
              {
                var dt = ln.Substring(pos + 1).Trim();
                if (!dt.ToLower().Contains("null"))
                {
                  try
                  {
                    endDateTime = DateTime.Parse(dt);
                  }
                  catch
                  {
                  }
                }
                continue;
              }
            }

            if (startDateTime.HasValue && endDateTime.HasValue)
            {
              var durationMilliseconds = (endDateTime.Value - startDateTime.Value).TotalMilliseconds;

              sql =
                $"UPDATE EmailRaw {g.crlf}" +
                $"  SET FunctionId = {functionId},{g.crlf}" +
                $"      FunctionName = '{function}',{g.crlf}" +
                $"      OriginalFunctionName = '{originalFunction}',{g.crlf}" +
                $"      ErrorOccurred = {(errorOccurred ? 1 : 0)},{g.crlf}" +
                $"      StartDateTime = '{startDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}',{g.crlf}" +
                $"      EndDateTime = '{endDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}',{g.crlf}" +
                $"      DurationMilliseconds = {durationMilliseconds}{g.crlf}" +
                $"  WHERE Id = {id}";

              try
              {
                cmd.CommandText = sql;
                var rows = cmd.ExecuteNonQuery();
              }
              catch
              {
                throw;
              }

              emailDataUpdated = true;
            }

            if (emailDataUpdated) break;
          }

          //sb.Append($"ID: {id}  {dateSent}  {subject}{g.crlf}");
          lblStatus.Text = $"ID: {id}  {dateSent}  {subject} updated:{emailDataUpdated}";
          Application.DoEvents();
        }

        var functionNames = $"FUNCTIONS:{g.crlf}";
        functions.Sort();
        
        foreach (var f in functions)
        {
          functionNames += f + g.crlf;
        }

        var report = $"{functionNames}{g.crlf2}{sb.ToString()}";

        rtxtOut.Text = report;

        conn.Close();
        conn.Dispose();

        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        this.Cursor = Cursors.Default;
        rtxtOut.Text = $"An error occurred while running the ProcessRawEmails method.{g.crlf}{ex.ToReport()}";
      }
    }

    private void LoadRawEmails()
    {
      try
      {
        rtxtOut.Text = "";
        Application.DoEvents();

        this.Cursor = Cursors.WaitCursor;
        var sb = new StringBuilder();

        var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand("", conn);

        var emailFiles = Directory.GetFiles(_emailFolder, "*.xml");
        foreach (var emailFile in emailFiles)
        {
          var emailXml = XElement.Parse(File.ReadAllText(emailFile));
          var dateSent = emailXml.Attribute("Sent").Value;
          var dtSent = dateSent.ToDateTime();

          var subject = emailXml.Element("Subject").Value.Trim();
          var body = emailXml.Element("Body").Value.Trim();

          var sql =
            $"SELECT DateSent, Subject {g.crlf}" +
            $"FROM EmailRaw{g.crlf}" +
            $"WHERE DateSent = '{dtSent.ToSqlDate()}'{g.crlf}" +
            $"  AND Subject = '{subject}' ";

          cmd.CommandText = sql;  
          var da = new SqlDataAdapter(cmd);
          var ds = new DataSet();
          da.Fill(ds);

          if (ds.Tables[0].Rows.Count > 0)
          {
            sb.Append($"{dateSent}  {subject} - ALREADY LOADED{g.crlf}");
            lblStatus.Text = $"{dateSent}  {subject} - ALREADY LOADED";
            Application.DoEvents();
            continue;
          }

          sql =
            $"INSERT INTO EmailRaw{g.crlf}" +
            $"({g.crlf}" +
            $"  DateSent,{g.crlf}" +
            $"  Subject,{g.crlf}" +
            $"  Body{g.crlf}" +
            $"){g.crlf}" +
            $"VALUES{g.crlf}" +
            $"({g.crlf}" +
            $"  '{dtSent.ToSqlDate()}',{g.crlf}" +
            $"  '{subject}',{g.crlf}" +
            $"  '{body.ToSqlString()}'{g.crlf}" +
            $");{g.crlf}" +
            $"SELECT SCOPE_IDENTITY();";

          cmd.CommandText = sql;
          var id = cmd.ExecuteScalar();

          sb.Append($"ID: {id}  {dateSent}  {subject}{g.crlf}");

          lblStatus.Text = $"ID: {id}  {dateSent}  {subject}";
          Application.DoEvents();
        }

        conn.Close();
        conn.Dispose();

        var report = sb.ToString();
        rtxtOut.Text = report;

        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        this.Cursor= Cursors.Default;
        rtxtOut.Text = $"An error occurred while running the LoadRawEmails method.{g.crlf}{ex.ToReport()}";
      }
    }

    private void LoadFunctionsComboBox()
    {
      try
      {
        return;

        _functionSet = new Dictionary<string, int>();

        var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand("", conn);

        var sql =
          $"SELECT DISTINCT{g.crlf}" +
          $" FunctionId,{g.crlf}" +
          $" FunctionName{g.crlf}" +
          $"FROM EmailRaw{g.crlf}" +
          $"WHERE FunctionID < 50{g.crlf}" +
          $"ORDER BY FunctionId";

        cmd.CommandText = sql;

        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        da.Fill(ds);

        foreach (DataRow r in ds.Tables[0].Rows)
        {
          var functionId = r["FunctionId"].DbToInt32();
          var functionName = r["FunctionName"].DbToString();

          if (functionId.HasValue && functionName.IsNotBlank())
          {
            if (!_functionSet.ContainsKey(functionName))
              _functionSet.Add(functionName, functionId.Value);
          }
        }

        conn.Close();
        conn.Dispose();

        cboFunctions.Items.Clear();
        foreach (var function in _functionSet)
        {
          cboFunctions.Items.Add(function.Key);
        }
        if (cboFunctions.Items.Count > 0)
          cboFunctions.SelectedIndex = 0; 
      }
      catch (Exception ex)
      {
        throw new Exception("An exception occurred while attempting to load the Functions combo box.", ex);
      }
    }

    private void InitializeForm()
    {
      try
      {
        this.SetInitialSizeAndLocation(75, 80);
        LoadFunctionsComboBox();

      }
      catch (Exception ex)
      {
        this.Cursor = Cursors.Default;
        rtxtOut.Text = $"An error occurred while initializing.{g.crlf}{ex.ToReport()}";
      }
    }
  }
}