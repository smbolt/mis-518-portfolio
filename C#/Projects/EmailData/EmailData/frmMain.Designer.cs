namespace EmailData
{
  partial class frmMain
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mnuMain = new System.Windows.Forms.MenuStrip();
      this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlTop = new System.Windows.Forms.Panel();
      this.lblFunctionName = new System.Windows.Forms.Label();
      this.cboFunctions = new System.Windows.Forms.ComboBox();
      this.ckGetAllRawEmails = new System.Windows.Forms.CheckBox();
      this.btnExtractCsv2 = new System.Windows.Forms.Button();
      this.btnExtractCsv = new System.Windows.Forms.Button();
      this.btnViewFunction = new System.Windows.Forms.Button();
      this.btnGetUnits = new System.Windows.Forms.Button();
      this.btnProcessRawEmails = new System.Windows.Forms.Button();
      this.btnLoadRawEmails = new System.Windows.Forms.Button();
      this.lblStatus = new System.Windows.Forms.Label();
      this.rtxtOut = new System.Windows.Forms.RichTextBox();
      this.btnExtractCsv3 = new System.Windows.Forms.Button();
      this.mnuMain.SuspendLayout();
      this.pnlTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // mnuMain
      // 
      this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
      this.mnuMain.Location = new System.Drawing.Point(0, 0);
      this.mnuMain.Name = "mnuMain";
      this.mnuMain.Size = new System.Drawing.Size(1173, 24);
      this.mnuMain.TabIndex = 0;
      this.mnuMain.Text = "mnuMain";
      // 
      // mnuFile
      // 
      this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
      this.mnuFile.Name = "mnuFile";
      this.mnuFile.Size = new System.Drawing.Size(37, 20);
      this.mnuFile.Text = "&File";
      // 
      // mnuFileExit
      // 
      this.mnuFileExit.Name = "mnuFileExit";
      this.mnuFileExit.Size = new System.Drawing.Size(93, 22);
      this.mnuFileExit.Tag = "Exit";
      this.mnuFileExit.Text = "E&xit";
      this.mnuFileExit.Click += new System.EventHandler(this.Action);
      // 
      // pnlTop
      // 
      this.pnlTop.Controls.Add(this.lblFunctionName);
      this.pnlTop.Controls.Add(this.cboFunctions);
      this.pnlTop.Controls.Add(this.ckGetAllRawEmails);
      this.pnlTop.Controls.Add(this.btnExtractCsv3);
      this.pnlTop.Controls.Add(this.btnExtractCsv2);
      this.pnlTop.Controls.Add(this.btnExtractCsv);
      this.pnlTop.Controls.Add(this.btnViewFunction);
      this.pnlTop.Controls.Add(this.btnGetUnits);
      this.pnlTop.Controls.Add(this.btnProcessRawEmails);
      this.pnlTop.Controls.Add(this.btnLoadRawEmails);
      this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTop.Location = new System.Drawing.Point(0, 24);
      this.pnlTop.Name = "pnlTop";
      this.pnlTop.Size = new System.Drawing.Size(1173, 76);
      this.pnlTop.TabIndex = 1;
      // 
      // lblFunctionName
      // 
      this.lblFunctionName.AutoSize = true;
      this.lblFunctionName.Location = new System.Drawing.Point(425, 10);
      this.lblFunctionName.Name = "lblFunctionName";
      this.lblFunctionName.Size = new System.Drawing.Size(89, 15);
      this.lblFunctionName.TabIndex = 3;
      this.lblFunctionName.Text = "Function Name";
      // 
      // cboFunctions
      // 
      this.cboFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboFunctions.FormattingEnabled = true;
      this.cboFunctions.Location = new System.Drawing.Point(425, 27);
      this.cboFunctions.Name = "cboFunctions";
      this.cboFunctions.Size = new System.Drawing.Size(174, 23);
      this.cboFunctions.TabIndex = 2;
      // 
      // ckGetAllRawEmails
      // 
      this.ckGetAllRawEmails.AutoSize = true;
      this.ckGetAllRawEmails.Location = new System.Drawing.Point(175, 52);
      this.ckGetAllRawEmails.Name = "ckGetAllRawEmails";
      this.ckGetAllRawEmails.Size = new System.Drawing.Size(123, 19);
      this.ckGetAllRawEmails.TabIndex = 1;
      this.ckGetAllRawEmails.Text = "Get All Raw Emails";
      this.ckGetAllRawEmails.UseVisualStyleBackColor = true;
      // 
      // btnExtractCsv2
      // 
      this.btnExtractCsv2.Location = new System.Drawing.Point(818, 26);
      this.btnExtractCsv2.Name = "btnExtractCsv2";
      this.btnExtractCsv2.Size = new System.Drawing.Size(95, 25);
      this.btnExtractCsv2.TabIndex = 0;
      this.btnExtractCsv2.Tag = "ExtractCsv2";
      this.btnExtractCsv2.Text = "Extract CSV 2";
      this.btnExtractCsv2.UseVisualStyleBackColor = true;
      this.btnExtractCsv2.Click += new System.EventHandler(this.Action);
      // 
      // btnExtractCsv
      // 
      this.btnExtractCsv.Location = new System.Drawing.Point(717, 26);
      this.btnExtractCsv.Name = "btnExtractCsv";
      this.btnExtractCsv.Size = new System.Drawing.Size(95, 25);
      this.btnExtractCsv.TabIndex = 0;
      this.btnExtractCsv.Tag = "ExtractCsv";
      this.btnExtractCsv.Text = "Extract CSV";
      this.btnExtractCsv.UseVisualStyleBackColor = true;
      this.btnExtractCsv.Click += new System.EventHandler(this.Action);
      // 
      // btnViewFunction
      // 
      this.btnViewFunction.Location = new System.Drawing.Point(605, 26);
      this.btnViewFunction.Name = "btnViewFunction";
      this.btnViewFunction.Size = new System.Drawing.Size(105, 25);
      this.btnViewFunction.TabIndex = 0;
      this.btnViewFunction.Tag = "ViewFunction";
      this.btnViewFunction.Text = "View Function";
      this.btnViewFunction.UseVisualStyleBackColor = true;
      this.btnViewFunction.Click += new System.EventHandler(this.Action);
      // 
      // btnGetUnits
      // 
      this.btnGetUnits.Location = new System.Drawing.Point(322, 26);
      this.btnGetUnits.Name = "btnGetUnits";
      this.btnGetUnits.Size = new System.Drawing.Size(97, 25);
      this.btnGetUnits.TabIndex = 0;
      this.btnGetUnits.Tag = "GetUnits";
      this.btnGetUnits.Text = "Get Units";
      this.btnGetUnits.UseVisualStyleBackColor = true;
      this.btnGetUnits.Click += new System.EventHandler(this.Action);
      // 
      // btnProcessRawEmails
      // 
      this.btnProcessRawEmails.Location = new System.Drawing.Point(168, 26);
      this.btnProcessRawEmails.Name = "btnProcessRawEmails";
      this.btnProcessRawEmails.Size = new System.Drawing.Size(148, 25);
      this.btnProcessRawEmails.TabIndex = 0;
      this.btnProcessRawEmails.Tag = "ProcessRawEmails";
      this.btnProcessRawEmails.Text = "Process Raw Emails";
      this.btnProcessRawEmails.UseVisualStyleBackColor = true;
      this.btnProcessRawEmails.Click += new System.EventHandler(this.Action);
      // 
      // btnLoadRawEmails
      // 
      this.btnLoadRawEmails.Location = new System.Drawing.Point(14, 26);
      this.btnLoadRawEmails.Name = "btnLoadRawEmails";
      this.btnLoadRawEmails.Size = new System.Drawing.Size(148, 25);
      this.btnLoadRawEmails.TabIndex = 0;
      this.btnLoadRawEmails.Tag = "LoadRawEmails";
      this.btnLoadRawEmails.Text = "Load Raw Emails";
      this.btnLoadRawEmails.UseVisualStyleBackColor = true;
      this.btnLoadRawEmails.Click += new System.EventHandler(this.Action);
      // 
      // lblStatus
      // 
      this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblStatus.Location = new System.Drawing.Point(0, 732);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblStatus.Size = new System.Drawing.Size(1173, 23);
      this.lblStatus.TabIndex = 2;
      this.lblStatus.Text = "Status";
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // rtxtOut
      // 
      this.rtxtOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.rtxtOut.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtxtOut.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.rtxtOut.Location = new System.Drawing.Point(0, 100);
      this.rtxtOut.Name = "rtxtOut";
      this.rtxtOut.Size = new System.Drawing.Size(1173, 632);
      this.rtxtOut.TabIndex = 3;
      this.rtxtOut.Text = "";
      this.rtxtOut.WordWrap = false;
      // 
      // btnExtractCsv3
      // 
      this.btnExtractCsv3.Location = new System.Drawing.Point(919, 26);
      this.btnExtractCsv3.Name = "btnExtractCsv3";
      this.btnExtractCsv3.Size = new System.Drawing.Size(95, 25);
      this.btnExtractCsv3.TabIndex = 0;
      this.btnExtractCsv3.Tag = "ExtractCsv3";
      this.btnExtractCsv3.Text = "Extract CSV 3";
      this.btnExtractCsv3.UseVisualStyleBackColor = true;
      this.btnExtractCsv3.Click += new System.EventHandler(this.Action);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1173, 755);
      this.Controls.Add(this.rtxtOut);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.pnlTop);
      this.Controls.Add(this.mnuMain);
      this.MainMenuStrip = this.mnuMain;
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Email Data";
      this.mnuMain.ResumeLayout(false);
      this.mnuMain.PerformLayout();
      this.pnlTop.ResumeLayout(false);
      this.pnlTop.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MenuStrip mnuMain;
    private ToolStripMenuItem mnuFile;
    private ToolStripMenuItem mnuFileExit;
    private Panel pnlTop;
    private Button btnGo;
    private Label lblStatus;
    private RichTextBox rtxtOut;
    private Button btnLoadRawEmails;
    private Button btnProcessRawEmails;
    private CheckBox ckGetAllRawEmails;
    private Label lblFunctionName;
    private ComboBox cboFunctions;
    private Button btnGetUnits;
    private Button btnViewFunction;
    private Button btnExtractCsv;
        private Button btnExtractCsv2;
        private Button btnExtractCsv3;
    }
}