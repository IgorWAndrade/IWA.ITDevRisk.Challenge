using System;

namespace IWA.ITDevRisk.Challenge.UI.View
{
    public class MainView
    {
        public static void ViewStart(string softwareName)
        {
            Console.WriteLine(String.Format("Iniciando os Serviços do {0}", softwareName));

            Console.WriteLine("Seja Bem-Vindo\nVamos coletar algumas informações abaixo:");
        }

        public static void ViewStop(string softwareName)
        {
            Console.WriteLine(String.Format("Encerrando os Serviços do {0}", softwareName));
            Console.ReadKey();
        }
    }
}
