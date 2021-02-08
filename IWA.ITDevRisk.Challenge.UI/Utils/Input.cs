using IWA.ITDevRisk.Challenge.UI.Enum;
using System;

namespace IWA.ITDevRisk.Challenge.UI.Utils
{
    public class Input
    {
        public static string ReadUserInput(string message, EOutputConvert typeFormatOutput)
        {
            int countErros = 0;
            string outputValid = "";

            do
            {
                if (countErros > 0)
                {
                    Console.WriteLine("Entrada Inválida :-(");
                }
                Console.WriteLine(message);

                outputValid = Console.ReadLine();
                countErros++;
            } while (Valid.Validade(outputValid, typeFormatOutput) == false);

            return outputValid;
        }

    }
}
