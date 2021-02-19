using IWA.ITDevRisk.Challenge.Business.Domain.Enum;
using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Domain;
using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Service;
using System.Collections.Generic;
using System.Globalization;

namespace IWA.ITDevRisk.Challenge.Business.Service
{
    public class TradeService : ITradeService
    {
        public ICollection<string> Avaliar(ITradeReference tradeReference, ICollection<ITrade> lista)
        {
            var listaResultados = new List<string>();
            double valorComparativo = double.Parse("10000", CultureInfo.InvariantCulture);

            foreach (var item in lista)
            {
                var difference = (item.NextPaymentDate - tradeReference.DateReference).Days;

                if (difference < 30)
                {
                    listaResultados.Add(SectorEnum.Default.ToString());
                }
                else if (item.ClientSector.Equals("Private") && item.Value > valorComparativo)
                {
                    listaResultados.Add(SectorEnum.HighRisk.ToString());
                }
                else if (item.ClientSector.Equals("Public") && item.Value > valorComparativo)
                {
                    listaResultados.Add(SectorEnum.MediumRisk.ToString());
                }
            }

            return listaResultados;
        }
    }
}
