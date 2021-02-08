using IWA.ITDevRisk.Challenge.UI.Enum;

namespace IWA.ITDevRisk.Challenge.UI.Utils
{
    public class Valid
    {
        public static bool Validade(string input, EOutputConvert typeFormatOutput)
        {
            try
            {
                switch (typeFormatOutput)
                {
                    case EOutputConvert.DateTime:
                        DateTimeUtil.ConvertStrInDateTime(input);
                        break;

                    case EOutputConvert.String:
                        input.ToString();
                        break;

                    case EOutputConvert.Char:
                        char.Parse(input);
                        break;

                    case EOutputConvert.Double:
                        double.Parse(input);
                        break;

                    case EOutputConvert.Int:
                        int.Parse(input);
                        break;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
