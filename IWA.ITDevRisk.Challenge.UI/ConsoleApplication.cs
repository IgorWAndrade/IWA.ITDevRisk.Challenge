using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Service;
using IWA.ITDevRisk.Challenge.UI.View;

namespace IWA.ITDevRisk.Challenge.UI
{
    public class ConsoleApplication
    {
        private readonly string SoftwareName = "IT Dev RISK";
        private readonly ITradeService _tradeService;

        public ConsoleApplication(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        public void Run()
        {
            MainView.ViewStart(SoftwareName);

            new TradeView(_tradeService).View();

            MainView.ViewStop(SoftwareName);            
        }
    }
}
