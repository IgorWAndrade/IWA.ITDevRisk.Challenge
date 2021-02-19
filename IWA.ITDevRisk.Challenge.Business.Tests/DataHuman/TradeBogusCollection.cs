using Bogus;
using IWA.ITDevRisk.Challenge.Business.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace IWA.ITDevRisk.Challenge.Business.Tests.DataHuman
{
    public class TradeBogusCollection
    {
        private static double VALOR_COMPARATIVO = double.Parse("10000", CultureInfo.InvariantCulture);

        public static List<Trade> CriarTradesParaDefault(int trades, DateTime dateReference)
        {
            var lista = new List<Trade>();
            var sector = new List<string>()
            {
                "Public",
                "Private"
            };

            var dataNextPayment = dateReference.AddDays(3);

            for (int i = 0; i < trades; i++)
            {
                var item = new Faker<Trade>("pt_BR")
                    .CustomInstantiator(t => new Trade(
                        t.Random.Double(1),
                        t.Random.ListItem(sector),
                        dataNextPayment
                        ));
                lista.Add(item);
            }

            return lista;
        }

        public static List<Trade> CriarTradesParaMediumRisk(int trades, DateTime dateReference)
        {
            var lista = new List<Trade>();


            var dataNextPayment = dateReference.AddDays(60);

            var valorNovo = VALOR_COMPARATIVO + 1;
            var valorComparativo = double.Parse(valorNovo.ToString(), CultureInfo.InvariantCulture);
            for (int i = 0; i < trades; i++)
            {
                var item = new Faker<Trade>("pt_BR")
                    .CustomInstantiator(t => new Trade(
                        valorComparativo,
                        "Public",
                        dataNextPayment
                        ));
                lista.Add(item);
            }

            return lista;
        }

        public static List<Trade> CriarTradesParaHighRisk(int trades, DateTime dateReference)
        {
            var lista = new List<Trade>();

            var dataNextPayment = dateReference.AddDays(60);

            var valorNovo = VALOR_COMPARATIVO + 1;
            var valorComparativo = double.Parse(valorNovo.ToString(), CultureInfo.InvariantCulture);

            for (int i = 0; i < trades; i++)
            {

                var item = new Faker<Trade>("pt_BR")
                    .CustomInstantiator(t => new Trade(
                       valorComparativo,
                       "Private",
                        dataNextPayment
                        ));
                lista.Add(item);
            }

            return lista;
        }

    }
}
