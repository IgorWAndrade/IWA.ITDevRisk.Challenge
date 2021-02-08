using System;

namespace IWA.ITDevRisk.Challenge.Business.Domain.Interface.Domain
{
    public interface ITradeReference
    {
        int Trades { get; }
        DateTime DateReference { get; }
    }
}
