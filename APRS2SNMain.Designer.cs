namespace APRS2SN
{
  partial class APRS2SN
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtDebug = new System.Windows.Forms.TextBox();
      this.lblCallsign = new System.Windows.Forms.Label();
      this.dtlCallsign = new System.Windows.Forms.Label();
      this.lblAprsStatus = new System.Windows.Forms.Label();
      this.lblSNStatus = new System.Windows.Forms.Label();
      this.dtlAPRSStatus = new System.Windows.Forms.Label();
      this.dtlSNStatus = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      this.chkLog = new System.Windows.Forms.CheckBox();
      this.cbLogLevel = new System.Windows.Forms.ComboBox();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtDebug
      // 
      this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDebug.Location = new System.Drawing.Point(2, 115);
      this.txtDebug.Multiline = true;
      this.txtDebug.Name = "txtDebug";
      this.txtDebug.ReadOnly = true;
      this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtDebug.Size = new System.Drawing.Size(330, 243);
      this.txtDebug.TabIndex = 0;
      // 
      // lblCallsign
      // 
      this.lblCallsign.AutoSize = true;
      this.lblCallsign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCallsign.Location = new System.Drawing.Point(13, 30);
      this.lblCallsign.Name = "lblCallsign";
      this.lblCallsign.Size = new System.Drawing.Size(55, 13);
      this.lblCallsign.TabIndex = 1;
      this.lblCallsign.Text = "Callsign:";
      // 
      // dtlCallsign
      // 
      this.dtlCallsign.AutoSize = true;
      this.dtlCallsign.Location = new System.Drawing.Point(66, 29);
      this.dtlCallsign.Name = "dtlCallsign";
      this.dtlCallsign.Size = new System.Drawing.Size(71, 13);
      this.dtlCallsign.TabIndex = 2;
      this.dtlCallsign.Text = "<CALLSIGN>";
      // 
      // lblAprsStatus
      // 
      this.lblAprsStatus.AutoSize = true;
      this.lblAprsStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAprsStatus.Location = new System.Drawing.Point(13, 43);
      this.lblAprsStatus.Name = "lblAprsStatus";
      this.lblAprsStatus.Size = new System.Drawing.Size(84, 13);
      this.lblAprsStatus.TabIndex = 3;
      this.lblAprsStatus.Text = "APRS Status:";
      // 
      // lblSNStatus
      // 
      this.lblSNStatus.AutoSize = true;
      this.lblSNStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSNStatus.Location = new System.Drawing.Point(13, 56);
      this.lblSNStatus.Name = "lblSNStatus";
      this.lblSNStatus.Size = new System.Drawing.Size(112, 13);
      this.lblSNStatus.TabIndex = 4;
      this.lblSNStatus.Text = "SpotterNet Status:";
      // 
      // dtlAPRSStatus
      // 
      this.dtlAPRSStatus.AutoSize = true;
      this.dtlAPRSStatus.Location = new System.Drawing.Point(104, 42);
      this.dtlAPRSStatus.Name = "dtlAPRSStatus";
      this.dtlAPRSStatus.Size = new System.Drawing.Size(45, 13);
      this.dtlAPRSStatus.TabIndex = 5;
      this.dtlAPRSStatus.Text = "Inactive";
      // 
      // dtlSNStatus
      // 
      this.dtlSNStatus.AutoSize = true;
      this.dtlSNStatus.Location = new System.Drawing.Point(132, 55);
      this.dtlSNStatus.Name = "dtlSNStatus";
      this.dtlSNStatus.Size = new System.Drawing.Size(45, 13);
      this.dtlSNStatus.TabIndex = 6;
      this.dtlSNStatus.Text = "Inactive";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(336, 24);
      this.menuStrip1.TabIndex = 7;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem});
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.optionsToolStripMenuItem.Text = "Options";
      // 
      // setupToolStripMenuItem
      // 
      this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
      this.setupToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
      this.setupToolStripMenuItem.Text = "Setup";
      this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
      // 
      // btnStart
      // 
      this.btnStart.Enabled = false;
      this.btnStart.Location = new System.Drawing.Point(16, 72);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 8;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStop
      // 
      this.btnStop.Enabled = false;
      this.btnStop.Location = new System.Drawing.Point(98, 71);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(75, 23);
      this.btnStop.TabIndex = 9;
      this.btnStop.Text = "Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // chkLog
      // 
      this.chkLog.AutoSize = true;
      this.chkLog.Location = new System.Drawing.Point(179, 76);
      this.chkLog.Name = "chkLog";
      this.chkLog.Size = new System.Drawing.Size(64, 17);
      this.chkLog.TabIndex = 10;
      this.chkLog.Text = "Logging";
      this.chkLog.UseVisualStyleBackColor = true;
      this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
      // 
      // cbLogLevel
      // 
      this.cbLogLevel.Enabled = false;
      this.cbLogLevel.FormattingEnabled = true;
      this.cbLogLevel.Items.AddRange(new object[] {
            "Errors",
            "All"});
      this.cbLogLevel.Location = new System.Drawing.Point(249, 74);
      this.cbLogLevel.Name = "cbLogLevel";
      this.cbLogLevel.Size = new System.Drawing.Size(82, 21);
      this.cbLogLevel.TabIndex = 11;
      this.cbLogLevel.Text = "Errors";
      // 
      // APRS2SN
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(336, 362);
      this.Controls.Add(this.cbLogLevel);
      this.Controls.Add(this.chkLog);
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.dtlSNStatus);
      this.Controls.Add(this.dtlAPRSStatus);
      this.Controls.Add(this.lblSNStatus);
      this.Controls.Add(this.lblAprsStatus);
      this.Controls.Add(this.dtlCallsign);
      this.Controls.Add(this.lblCallsign);
      this.Controls.Add(this.txtDebug);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "APRS2SN";
      this.Text = "APRS2SN";
      this.Shown += new System.EventHandler(this.APRS2SN_Shown);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtDebug;
    private System.Windows.Forms.Label lblCallsign;
    private System.Windows.Forms.Label dtlCallsign;
    private System.Windows.Forms.Label lblAprsStatus;
    private System.Windows.Forms.Label lblSNStatus;
    private System.Windows.Forms.Label dtlAPRSStatus;
    private System.Windows.Forms.Label dtlSNStatus;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.CheckBox chkLog;
    private System.Windows.Forms.ComboBox cbLogLevel;
  }
}

