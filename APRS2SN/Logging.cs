using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using aprsparser;

namespace APRS2SN
{
  class Logging
  {
    private string sLogFileName;
    private object oLock = new object();
    public Logging(string sFileName)
    {
      sLogFileName = sFileName;
      if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\Logs"))
        Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Logs");
    }

    public void LogException(Exception ex)
    {
      lock(oLock)
      {
        List<string> lstsLines = new List<string>();

        lstsLines.Add($"{DateTime.UtcNow.ToString(Constants.Utility.DATE_TIME_FORMAT + ".ffffff")}: Exception thrown:");
        lstsLines.Add(ex.Message);
        lstsLines.Add(String.Empty);
        lstsLines.Add(ex.StackTrace);
        lstsLines.Add("***");

        File.AppendAllLines($"{Directory.GetCurrentDirectory()}\\Logs\\{sLogFileName}", lstsLines);
      }            
    }

    public void LogInformation(string sInformation)
    {
      lock(oLock)
      {
        List<string> lstsLines = new List<string>();

        lstsLines.Add($"{DateTime.UtcNow.ToString(Constants.Utility.DATE_TIME_FORMAT + ".ffffff")}: Information ");
        lstsLines.Add(sInformation);
        lstsLines.Add("***");

        File.AppendAllLines($"{Directory.GetCurrentDirectory()}\\Logs\\{sLogFileName}", lstsLines);
      }      
    }

    public void LogAPRSPacket(AprsPacket oPacket)
    {
      lock(oLock)
      {
        List<string> lstsLines = new List<string>();
        lstsLines.Add($"{DateTime.UtcNow.ToString(Constants.Utility.DATE_TIME_FORMAT + ".ffffff")}: Received Packet ");
        lstsLines.Add($"Callsign: {oPacket.SourceCallsign.StationCallsign}");
        lstsLines.Add($"Time: {oPacket.TimeStamp}");
        lstsLines.Add($"Latitude {oPacket.Position.CoordinateSet.Latitude.Value}");
        lstsLines.Add($"Longitude: {oPacket.Position.CoordinateSet.Longitude.Value}");
        lstsLines.Add($"Elevation: {oPacket.Position.Altitude}");
        lstsLines.Add($"Speed: {oPacket.Position.Speed}");
        lstsLines.Add($"Dir: {oPacket.Position.Course}");
        //lstsLines.Add($"Status: {oPacket.InformationField}");
        lstsLines.Add($"Type: {oPacket.DataType}");
        lstsLines.Add($"Message: {oPacket.MessageData.MsgText}");
        lstsLines.Add($"Comment: {oPacket.Comment}");
        lstsLines.Add("***");

        File.AppendAllLines($"{Directory.GetCurrentDirectory()}\\Logs\\{sLogFileName}", lstsLines);
      }
    }

    public void LogHTTPResponse(HttpResponseMessage oResponse)
    {
      lock(oLock)
      {
        List<string> lstsLines = new List<string>();
        lstsLines.Add($"{DateTime.UtcNow.ToString(Constants.Utility.DATE_TIME_FORMAT + ".ffffff")}: HTTP Response ");
        lstsLines.Add($"Status Code: {oResponse.StatusCode}");
        lstsLines.Add($"Request Message: {oResponse.RequestMessage}");
        lstsLines.Add($"Response Content: {oResponse.Content}");
        lstsLines.Add("***");

        File.AppendAllLines($"{Directory.GetCurrentDirectory()}\\Logs\\{sLogFileName}", lstsLines);
      }
    }
  }
}
