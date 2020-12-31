namespace APRS2SN
{
  class Constants
  {
    public class APRS
    {
      public static string ConnectTestString(string sCallsign)
      {
        return $"user {sCallsign} pass -1 vers APRS2SN 1.0 filter r/34.75/-85.25/200\r\n"; 
      }

      public static string ConnectString(string sCallsign)
      {
        return $"user {sCallsign} pass -1 vers APRS2SN 1.0 filter b/{sCallsign}*\r\n";
      }
    }
    public class URLS
    {
      public const string GET_POSITIONS = "https://www.spotternetwork.org/positions";
      public const string UPDATE_POSITIONS = "https://www.spotternetwork.org/positions/update";
      public const string APRSIS_SERVER = "noam.aprs2.net";
    }
    public class Utility
    {
      public const string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
      public const string APPLICATION_TYPE_JSON = "application/json";
      public const string SETTINGS_FILE = "APRS2SN.set";

      public class RegexStrings
      {
        public const string APPLICATION_ID = "APPLICATION_ID:\\S*";
        public const string PUBLIC_ID = "PUBLIC_ID:\\d*";
        public const string CALLSIGN = "CALLSIGN:\\S*";
        public const string COMMENT = "COMMENT:\\S*";
      }
    }
    public class PositionRequestFields
    {
      public const string ID = "id";
      public const string MARKERS = "markers";
    }
    public class PositionDetailFields
    {
      public const string POSITIONS = "positions";
      public const string ID = "id";
      public const string REPORT_AT = "report_at";
      public const string LAT = "lat";
      public const string LON = "lon";
      public const string DIR = "dir";
      public const string MARKER = "marker";
      public const string ACTIVE = "active";
      public const string GPS = "gps";
    }
  }
}
