using Bogus;
using IWA.ITDevRisk.Challenge.Business.Domain.Entity;
using System;
using System.Globalization;

namespace IWA.ITDevRisk.Challenge.Business.Tests.DataHuman
{
    public static class TradeReferenceBogusCollection
    {
        public static TradeReference CriarTradeReference()
        {
            Random rnd = new Random();
            var strFormat = string.Format("{0}/{1}/{2}", DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
            return new TradeReference(
               rnd.Next(1, 10),
               ConvertStrInDateTime(strFormat));
        }

        private static DateTime ConvertStrInDateTime(string dateTimeStr, string cultureInfo = "")
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
