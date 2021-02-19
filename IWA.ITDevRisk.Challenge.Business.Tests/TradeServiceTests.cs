using IWA.ITDevRisk.Challenge.Business.Domain.Enum;
using IWA.ITDevRisk.Challenge.Business.Service;
using IWA.ITDevRisk.Challenge.Business.Tests.DataHuman;
using Moq.AutoMock;
using Xunit;

namespace IWA.ITDevRisk.Challenge.Business.Tests
{
    public class TradeServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly TradeService _tradeService;


        public TradeServiceTests()
        {
            _mocker = new AutoMocker();
            _tradeService = _mocker.CreateInstance<TradeService>();
        }

        [Fact(DisplayName = "Todos Trade Reference devem ser Default")]
        [Trait("Trade Service", "Trades Default Bogus")]
        public void TradeService_Avaliar_DeveSerTodosDefault()
        {
            // Arrange
            var tradeReferences = TradeReferenceBogusCollection.CriarTradeReference();
            var lista = TradeBogusCollection.CriarTradesParaDefault(tradeReferences.Trades, tradeReferences.DateReference);

            // Act
            var results = _tradeService.Avaliar(tradeReferences, lista.ToArray());

            // Assert  
            Assert.All(results, trade => trade.Equals(SectorEnum.Default.ToString()));
            Assert.Equal(tradeReferences.Trades, results.Count);
        }

        [Fact(DisplayName = "Todos Trade Reference devem ser HighRisk")]
        [Trait("Trade Service", "Trades HighRisk Bogus")]
        public void TradeService_Avaliar_DeveSerTodosHighRisk()
        {
            // Arrange
            var tradeReferences = TradeReferenceBogusCollection.CriarTradeReference();
            var lista = TradeBogusCollection.CriarTradesParaHighRisk(tradeReferences.Trades, tradeReferences.DateReference);

            // Act
            var results = _tradeService.Avaliar(tradeReferences, lista.ToArray());

            // Assert  
            Assert.All(results, trade => trade.Equals(SectorEnum.HighRisk.ToString()));
            Assert.Equal(tradeReferences.Trades, results.Count);
        }

        [Fact(DisplayName = "Todos Trade Reference devem ser MediumRisk")]
        [Trait("Trade Service", "Trades MediumRisk Bogus")]
        public void TradeService_Avaliar_DeveSerTodosMediumRisk()
        {
            // Arrange
            var tradeReferences = TradeReferenceBogusCollection.CriarTradeReference();
            var lista = TradeBogusCollection.CriarTradesParaMediumRisk(tradeReferences.Trades, tradeReferences.DateReference);

            // Act
            var results = _tradeService.Avaliar(tradeReferences, lista.ToArray());

            // Assert  
            Assert.All(results, trade => trade.Equals(SectorEnum.MediumRisk.ToString()));
            Assert.Equal(tradeReferences.Trades, results.Count);
        }
    }
}
