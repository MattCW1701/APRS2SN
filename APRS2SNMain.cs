using aprsparser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace APRS2SN
{
  public partial class APRS2SN : Form
  {
    private string sApplicationID;
    private int iPublicID;
    private string sCallsign;
    private string sCommentSearch;
    private TcpClient tcpClient;
    private Thread thAPRSThread;
    private HttpClient oSNClient;
    private volatile bool bRunUpdate = false;
    private Logging oLogging;
    private bool bLogAll = false;

    public delegate void UpdateTextbox(AprsPacket oPacket);
    public UpdateTextbox UpdateTextboxDelegate;

    public APRS2SN()
    {
      UpdateTextboxDelegate = new UpdateTextbox(UpdateTextBox);
      oSNClient = new HttpClient();
      InitializeComponent();
    }

    #region Events
    #region Form events
    private void APRS2SN_Shown(object sender, EventArgs e)
    {
      if (File.Exists(Constants.Utility.SETTINGS_FILE))
      {
        ReadSettingsFile();
        dtlCallsign.Text = sCallsign;
        btnStart.Enabled = true;
      }
      else
      {
        DialogResult oResult = MessageBox.Show("Settings were not loaded, do you want to set them now?", "Settings", MessageBoxButtons.YesNo);
        switch (oResult)
        {
          case DialogResult.Yes:
            Settings frmSetting = new Settings();
            frmSetting.ShowDialog(this);
            break;
          case DialogResult.No:
            break;
          default:
            break;
        }
      }
    }
    #endregion

    #region Control events
    private void btnStart_Click(object sender, EventArgs e)
    {
      if(chkLog.Checked)
      {
        oLogging = new Logging($"{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}_APRS2SN.log");
        bLogAll = cbLogLevel.Text.Equals("All");
      }
        
      chkLog.Enabled = false;
      cbLogLevel.Enabled = false;
      btnStart.Enabled = false;
      btnStop.Enabled = true;
      dtlAPRSStatus.Text = "Active";
      dtlSNStatus.Text = "Active";
      tcpClient = new TcpClient(Constants.URLS.APRSIS_SERVER, 14580);
      NetworkStream nsStream = tcpClient.GetStream();
      bool bIDRcv = false;
      byte[] yarData;
      while (!bIDRcv)
      {
        yarData = new byte[256];
        int bytes = nsStream.Read(yarData, 0, yarData.Length);
        string sRead = Encoding.ASCII.GetString(yarData, 0, bytes);
        if (!string.IsNullOrWhiteSpace(sRead))
          bIDRcv = true;

        if (chkLog.Checked && bLogAll)
          oLogging.LogInformation(sRead);
      }
      yarData = Encoding.ASCII.GetBytes(Constants.APRS.ConnectString(sCallsign));
      //yarData = Encoding.ASCII.GetBytes(Constants.APRS.ConnectTestString(sCallsign));
      nsStream.Write(yarData, 0, yarData.Length);

      bRunUpdate = true;
      thAPRSThread = new Thread(ReadAPRS);
      thAPRSThread.Start();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      bRunUpdate = false;
      Thread.Sleep(1000);
      thAPRSThread.Join(1000);
      tcpClient.Close();
      
      btnStart.Enabled = true;
      btnStop.Enabled = false;
      chkLog.Enabled = true;
      cbLogLevel.Enabled = true;

      dtlAPRSStatus.Text = "Inactive";
      dtlSNStatus.Text = "Inactive";
      txtDebug.Text = string.Empty;
    }

    private void chkLog_CheckedChanged(object sender, EventArgs e)
    {
      cbLogLevel.Enabled = ((CheckBox)sender).Checked;
    }

    private void setupToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Settings frmSetting = new Settings(Constants.Utility.SETTINGS_FILE);
      frmSetting.ShowDialog(this);
    }
    #endregion
    #endregion

    /// <summary>
    /// Method run by a thread to read information from APRS-IS and update SpotterNetwork
    /// </summary>
    private void ReadAPRS()
    {
      NetworkStream nsStream = tcpClient.GetStream();
      AprsPacket oPacket = new AprsPacket();
      while (bRunUpdate)
      {
        byte[] yarData = new byte[256];
        if (!nsStream.CanRead || !nsStream.DataAvailable)
          continue;
        int iByteCount = nsStream.Read(yarData, 0, yarData.Length);
        if (iByteCount > 0)
        {
          string sRead = Encoding.ASCII.GetString(yarData, 0, iByteCount);
          try
          {
            if (oPacket.Parse(sRead) && (oPacket.DataType.Equals(PacketDataType.Position) ||
                                         oPacket.DataType.Equals(PacketDataType.PositionMsg) ||
                                         oPacket.DataType.Equals(PacketDataType.PositionTime) ||
                                         oPacket.DataType.Equals(PacketDataType.PositionTimeMsg) ||
                                         oPacket.DataType.Equals(PacketDataType.MicE)) && PacketHasSearchComment(oPacket))
            {
              txtDebug.Invoke(UpdateTextboxDelegate, oPacket);
              if (chkLog.Checked && bLogAll)
                oLogging.LogAPRSPacket(oPacket);

              DateTime dtLastReported = new DateTime();
              HttpResponseMessage oResponse = SendPost(SetupDataForRequest(), Constants.URLS.GET_POSITIONS);
              if (oResponse.IsSuccessStatusCode)
              {
                string oResult = oResponse.Content.ReadAsStringAsync().Result;
                Dictionary<string, Dictionary<string, string>[]> dictResponses = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>[]>>(oResult);
                dtLastReported = DateTime.Parse(dictResponses[Constants.PositionDetailFields.POSITIONS][0][Constants.PositionDetailFields.REPORT_AT]);
                if (chkLog.Checked && bLogAll)
                  oLogging.LogHTTPResponse(oResponse);
              }
              else
              {
                if (chkLog.Checked)
                  oLogging.LogHTTPResponse(oResponse);
              }
              
              if (!dtLastReported.Equals(DateTime.MinValue) && !oPacket.TimeStamp.IsLocalTime && oPacket.TimeStamp.TimeStamp < dtLastReported)
                continue;

              if (oPacket.TimeStamp.TimeStamp == null || oPacket.TimeStamp.TimeStamp.Equals(DateTime.MinValue))
                oPacket.TimeStamp.TimeStamp = DateTime.UtcNow;

              HttpResponseMessage oPositionReponse = SendPost(SetupDataForUpdate(oPacket), Constants.URLS.UPDATE_POSITIONS);
              if ((!oPositionReponse.IsSuccessStatusCode || bLogAll) && chkLog.Checked)
              {
                oLogging.LogHTTPResponse(oResponse);
              }
            }
          }
          catch (Exception ex)
          {
            if(chkLog.Checked)
              oLogging.LogException(ex);
          }
        }
      }
      nsStream.Close();
      if(chkLog.Checked)
        oLogging.LogInformation("Thread terminated.");
    }

    /// <summary>
    /// Method to update the main textbox with information from the latest APRS packet received
    /// </summary>
    /// <param name="oPacket"></param>
    private void UpdateTextBox(AprsPacket oPacket)
    {
      txtDebug.Text = $"Callsign: {oPacket.SourceCallsign.StationCallsign}{Environment.NewLine}";
      txtDebug.Text += $"Time: {oPacket.TimeStamp.TimeStamp}{Environment.NewLine}";
      txtDebug.Text += $"Latitude {oPacket.Position.CoordinateSet.Latitude.Value}{Environment.NewLine}";
      txtDebug.Text += $"Longitude: {oPacket.Position.CoordinateSet.Longitude.Value}{Environment.NewLine}";
      txtDebug.Text += $"Elevation: {oPacket.Position.Altitude}{Environment.NewLine}";
      txtDebug.Text += $"Speed: {oPacket.Position.Speed}{Environment.NewLine}";
      txtDebug.Text += $"Dir: {oPacket.Position.Course}{Environment.NewLine}";
      //txtDebug.Text += $"Status: {oPacket.InformationField}{Environment.NewLine}";
      txtDebug.Text += $"Type: {oPacket.DataType}{Environment.NewLine}";
      txtDebug.Text += $"Message: {oPacket.MessageData.MsgText}{Environment.NewLine}";
      txtDebug.Text += $"Comment: {oPacket.Comment}";
    }

    /// <summary>
    /// Method that reads the settings file
    /// </summary>
    private void ReadSettingsFile()
    {
      bool bAllSettingsLoaded = false;
      bool bApplicationIDRead = false, bPublicIdRead = false, bCallsignRead = false, bCommentSearchRead = false;
      while (!bAllSettingsLoaded)
      {
        string sLine;
        string[] sarSplit;
        Regex rApplicationIDLine = new Regex(Constants.Utility.RegexStrings.APPLICATION_ID);
        Regex rPublicIDLine = new Regex(Constants.Utility.RegexStrings.PUBLIC_ID);
        Regex rCallsign = new Regex(Constants.Utility.RegexStrings.CALLSIGN);
        Regex rComment = new Regex(Constants.Utility.RegexStrings.COMMENT);

        using (StreamReader srReader = File.OpenText(Constants.Utility.SETTINGS_FILE))
        {
          while ((sLine = srReader.ReadLine()) != null)
          {
            sarSplit = sLine.Split(':');
            if (rApplicationIDLine.IsMatch(sLine))
            {
              sApplicationID = sarSplit[1];
              bApplicationIDRead = true;
            }
            else if (rPublicIDLine.IsMatch(sLine))
            {
              iPublicID = int.Parse(sarSplit[1]);
              bPublicIdRead = true;
            }
            else if (rCallsign.IsMatch(sLine))
            {
              sCallsign = sarSplit[1];
              bCallsignRead = true;
            }
            else if (rComment.IsMatch(sLine))
            {
              sCommentSearch = sarSplit[1];
              bCommentSearchRead = true;
            }
          }
        }

        if (!bApplicationIDRead || !bPublicIdRead || !bCallsignRead || !bCommentSearchRead)
        {
          string sMessage = "The following options were not set:\r\n";
          if (!bApplicationIDRead)
            sMessage += "*Application ID\r\n";

          if (!bPublicIdRead)
            sMessage += "*Public ID\r\n";

          if (!bCallsignRead)
            sMessage += "*Callsign\r\n";

          if (!bCommentSearchRead)
            sMessage += "*Comment to Search for (optional)\r\n";

          sMessage += "Do you wish to set these settings now?";

          DialogResult oResult = MessageBox.Show(sMessage, "Settings", MessageBoxButtons.YesNo);
          switch (oResult)
          {
            case DialogResult.Yes:
              Settings frmSetting = new Settings(Constants.Utility.SETTINGS_FILE);
              frmSetting.ShowDialog(this);
              break;
            case DialogResult.No:
              return;
            default:
              break;
          }
        }
        else
        {
          bAllSettingsLoaded = true;
        }
      }      
    }

    /// <summary>
    /// Method that sends a POST to the specified URL
    /// </summary>
    /// <param name="dictData"></param>
    /// <param name="sURL"></param>
    /// <returns></returns>
    private HttpResponseMessage SendPost(Dictionary<string, object> dictData, string sURL)
    {
      string sRequestJSON = JsonConvert.SerializeObject(dictData);
      StringContent scRequestContent = new StringContent(sRequestJSON, Encoding.UTF8, Constants.Utility.APPLICATION_TYPE_JSON);
      return oSNClient.PostAsync(sURL, scRequestContent).Result;
    }

    /// <summary>
    /// Method to determine if the incoming APRS packet has the comment we're searching for
    /// </summary>
    /// <param name="oPacket"></param>
    /// <returns></returns>
    private bool PacketHasSearchComment(AprsPacket oPacket)
    {
      bool bReturn = true;
      if (!string.IsNullOrWhiteSpace(sCommentSearch))
        bReturn = oPacket.Comment.Contains(sCommentSearch);

      return bReturn;
    }

    /// <summary>
    /// Sets up a dictionary of data to be passed when requesting the most recent position of a spotter.
    /// </summary>
    /// <returns></returns>
    private Dictionary<string, object> SetupDataForRequest()
    {
      return new Dictionary<string, object>
            {
              {Constants.PositionRequestFields.ID,sApplicationID},
              {Constants.PositionRequestFields.MARKERS, new string[]{iPublicID.ToString()} }
            };
    }

    /// <summary>
    /// Sets up a dictionary of data to be passed when updating the position of the spotter.
    /// </summary>
    /// <param name="oPacket"></param>
    /// <returns></returns>
    private Dictionary<string, object> SetupDataForUpdate(AprsPacket oPacket)
    {
      return new Dictionary<string, object>
            {
              {Constants.PositionDetailFields.ID, sApplicationID},
              {Constants.PositionDetailFields.REPORT_AT, oPacket.TimeStamp.TimeStamp.Value.ToString(Constants.Utility.DATE_TIME_FORMAT)},
              {Constants.PositionDetailFields.LAT, oPacket.Position.CoordinateSet.Latitude.Value},
              {Constants.PositionDetailFields.LON, oPacket.Position.CoordinateSet.Longitude.Value},
              {Constants.PositionDetailFields.DIR, oPacket.Position.Course},
              {Constants.PositionDetailFields.ACTIVE, 1},
              {Constants.PositionDetailFields.GPS, 1}
            };
    }
  }
}
