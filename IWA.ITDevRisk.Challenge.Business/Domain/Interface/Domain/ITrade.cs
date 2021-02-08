using System;

namespace IWA.ITDevRisk.Challenge.Business.Domain.Interface.Domain
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }
}
