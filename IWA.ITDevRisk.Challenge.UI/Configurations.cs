using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Repository;
using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Service;
using IWA.ITDevRisk.Challenge.Business.Infra;
using IWA.ITDevRisk.Challenge.Business.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IWA.ITDevRisk.Challenge.UI
{
    public static class Configurations
    {
        private static IServiceProvider _serviceProvider;

        public static void Build()
        {
            var services = new ServiceCollection();


            //Repository
            services.AddSingleton<ITradeRepository, TradeRepository>();

            //Service
            services.AddSingleton<ITradeService, TradeService>();

            //UI
            services.AddSingleton<ConsoleApplication>();


            _serviceProvider = services.BuildServiceProvider(true);
        }

        public static void Start()
        {
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
        }

        public static void Dispose()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
