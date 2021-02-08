using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Domain;
using System.Collections.Generic;

namespace IWA.ITDevRisk.Challenge.Business.Domain.Interface.Service
{
    public interface ITradeService
    {
        ICollection<string> Avaliar(ITradeReference tradeReference, ICollection<ITrade> lista);
    }
}
