using System;

namespace IWA.ITDevRisk.Challenge.UI
{
    class Program
    {

        static void Main(string[] args)
        {
            Configurations.Build();

            Configurations.Start();

            Configurations.Dispose();
        }
    }
}