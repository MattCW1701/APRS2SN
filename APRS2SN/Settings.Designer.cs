namespace APRS2SN
{
  partial class Settings
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
      this.txtApplicationID = new System.Windows.Forms.TextBox();
      this.txtPublicID = new System.Windows.Forms.TextBox();
      this.txtCallsign = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.txtCommentSearch = new System.Windows.Forms.TextBox();
      this.lblComment = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // txtApplicationID
      // 
      this.txtApplicationID.Location = new System.Drawing.Point(123, 12);
      this.txtApplicationID.Name = "txtApplicationID";
      this.txtApplicationID.Size = new System.Drawing.Size(100, 20);
      this.txtApplicationID.TabIndex = 0;
      // 
      // txtPublicID
      // 
      this.txtPublicID.Location = new System.Drawing.Point(123, 38);
      this.txtPublicID.Name = "txtPublicID";
      this.txtPublicID.Size = new System.Drawing.Size(100, 20);
      this.txtPublicID.TabIndex = 1;
      // 
      // txtCallsign
      // 
      this.txtCallsign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtCallsign.Location = new System.Drawing.Point(123, 64);
      this.txtCallsign.Name = "txtCallsign";
      this.txtCallsign.Size = new System.Drawing.Size(100, 20);
      this.txtCallsign.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(94, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "SN Application ID:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(46, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(71, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "SN Public ID:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(71, 67);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(46, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Callsign:";
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(123, 119);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // txtCommentSearch
      // 
      this.txtCommentSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtCommentSearch.Location = new System.Drawing.Point(123, 91);
      this.txtCommentSearch.Name = "txtCommentSearch";
      this.txtCommentSearch.Size = new System.Drawing.Size(100, 20);
      this.txtCommentSearch.TabIndex = 3;
      // 
      // lblComment
      // 
      this.lblComment.AutoSize = true;
      this.lblComment.Location = new System.Drawing.Point(17, 94);
      this.lblComment.Name = "lblComment";
      this.lblComment.Size = new System.Drawing.Size(100, 13);
      this.lblComment.TabIndex = 8;
      this.lblComment.Text = "(optional) Comment:";
      // 
      // Settings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(235, 150);
      this.Controls.Add(this.lblComment);
      this.Controls.Add(this.txtCommentSearch);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtCallsign);
      this.Controls.Add(this.txtPublicID);
      this.Controls.Add(this.txtApplicationID);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "Settings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.Settings_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtApplicationID;
    private System.Windows.Forms.TextBox txtPublicID;
    private System.Windows.Forms.TextBox txtCallsign;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.TextBox txtCommentSearch;
    private System.Windows.Forms.Label lblComment;
  }
}