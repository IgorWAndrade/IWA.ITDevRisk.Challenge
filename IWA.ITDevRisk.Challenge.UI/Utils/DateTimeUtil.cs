using System;
using System.Globalization;

namespace IWA.ITDevRisk.Challenge.UI.Utils
{
    public class DateTimeUtil
    {
        public static DateTime ConvertStrInDateTime(string dateTimeStr, string cultureInfo = "")
        {
            DateTimeFormatInfo usDtfi = null;
            if (string.IsNullOrEmpty(cultureInfo))
            {
                usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
            }
            else
            {
                usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
            }
            return Convert.ToDateTime(dateTimeStr, usDtfi);
        }
    }
}
