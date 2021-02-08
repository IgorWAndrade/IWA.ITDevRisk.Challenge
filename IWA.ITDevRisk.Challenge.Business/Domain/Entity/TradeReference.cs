using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Domain;
using System;

namespace IWA.ITDevRisk.Challenge.Business.Domain.Entity
{
    public class TradeReference : ITradeReference
    {
        public TradeReference(int trades, DateTime date)
        {
            this.Trades = trades;
            this.DateReference = date;
        }

        public int Trades { get; }

        public DateTime DateReference { get; }
    }
}
