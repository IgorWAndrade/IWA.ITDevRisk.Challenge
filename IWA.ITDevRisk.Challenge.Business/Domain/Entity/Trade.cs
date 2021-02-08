using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Domain;
using System;

namespace IWA.ITDevRisk.Challenge.Business.Domain.Entity
{
    public class Trade : ITrade
    {
        public Trade(double value, string clientSector, DateTime nextPayment)
        {
            this.Value = value;
            this.ClientSector = clientSector;
            this.NextPaymentDate = nextPayment;
        }

        public double Value { get; }

        public string ClientSector { get; }

        public DateTime NextPaymentDate { get; }
    }
}
