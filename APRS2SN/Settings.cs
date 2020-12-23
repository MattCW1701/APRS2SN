using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace APRS2SN
{
  public partial class Settings : Form
  {
    string sSettingsFileName;
    public Settings()
    {
      InitializeComponent();
    }

    public Settings(string sFileName)
    {
      sSettingsFileName = sFileName;
      InitializeComponent();
    }

    private void Settings_Load(object sender, EventArgs e)
    {
      if(sSettingsFileName != null && !string.IsNullOrWhiteSpace(sSettingsFileName) && File.Exists(sSettingsFileName))
      {
        using (StreamReader srReader = File.OpenText(sSettingsFileName))
        {
          string sLine;
          string[] arsSplit;
          Regex rApplicationIDLine = new Regex(Constants.Utility.RegexStrings.APPLICATION_ID);
          Regex rPublicIDLine = new Regex(Constants.Utility.RegexStrings.PUBLIC_ID);
          Regex rCallsign = new Regex(Constants.Utility.RegexStrings.CALLSIGN);
          Regex rComment = new Regex(Constants.Utility.RegexStrings.COMMENT);

          while ((sLine = srReader.ReadLine()) != null)
          {
            arsSplit = sLine.Split(':');
            if (rApplicationIDLine.IsMatch(sLine))
            {
              txtApplicationID.Text = arsSplit[1];
            }
            else if (rPublicIDLine.IsMatch(sLine))
            {
              txtPublicID.Text = arsSplit[1];
            }
            else if (rCallsign.IsMatch(sLine))
            {
              txtCallsign.Text = arsSplit[1];
            }
            else if(rComment.IsMatch(sLine))
            {
              txtCommentSearch.Text = arsSplit[1];
            }
          }
        }
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if(string.IsNullOrWhiteSpace(txtApplicationID.Text))
      {
        Validation(txtApplicationID, "Application ID cannot be empty!");
        return;
      }

      if(string.IsNullOrWhiteSpace(txtPublicID.Text))
      {
        Validation(txtPublicID, "Public ID cannot be empty!");
        return;
      }

      if(!Regex.IsMatch(txtPublicID.Text, @"\d*"))
      {
        Validation(txtPublicID, "Public ID must be numeric!");
        return;
      }

      if(string.IsNullOrWhiteSpace(txtCallsign.Text))
      {
        Validation(txtCallsign, "Callsign cannot be empty!");
        return;
      }

      using (StreamWriter swWriter = File.CreateText(sSettingsFileName))
      {
        swWriter.WriteLine($"APPLICATION_ID:{txtApplicationID.Text}");
        swWriter.WriteLine($"PUBLIC_ID:{txtPublicID.Text}");
        swWriter.WriteLine($"CALLSIGN:{txtCallsign.Text.ToUpper()}");
        if(!string.IsNullOrWhiteSpace(txtCommentSearch.Text))
          swWriter.WriteLine($"COMMENT:{txtCommentSearch.Text.ToUpper()}");        
      }
      this.Close();
    }
    
    private void Validation(TextBox txtBox, string sMessage)
    {
      MessageBox.Show(sMessage, "Error!", MessageBoxButtons.OK);
      txtBox.Focus();
    }
  }
}
