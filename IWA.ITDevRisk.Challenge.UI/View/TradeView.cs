using IWA.ITDevRisk.Challenge.Business.Domain.Entity;
using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Domain;
using IWA.ITDevRisk.Challenge.Business.Domain.Interface.Service;
using IWA.ITDevRisk.Challenge.UI.Enum;
using IWA.ITDevRisk.Challenge.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWA.ITDevRisk.Challenge.UI.View
{
    public class TradeView
    {
        private readonly ITradeService _tradeService;

        private bool WishContinue = false;

        private static ICollection<ITrade> _trades;

        public TradeView(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        public void View()
        {
            #region Coletar Informações Para TradeReference

            DateTime dataReferencia = DateTimeUtil.ConvertStrInDateTime(Input.ReadUserInput("Informe a data de referência (mm/dd/yyyy):", EOutputConvert.DateTime));

            int numeroNegocios = int.Parse(Input.ReadUserInput("Informe o número de negócios do Portfólio:", EOutputConvert.Int));

            var tradeReference = new TradeReference(numeroNegocios, dataReferencia);

            #endregion

            #region Coletar Informações para Trades

            ViewElement(numeroNegocios);

            #endregion

            #region Processar o Negocio

            Console.WriteLine("\nAguarde estamos avaliando suas informações...");
            var result = _tradeService.Avaliar(tradeReference, _trades);

            #endregion

            #region Resultado

            ViewElementAvaliacao(result.ToList());

            #endregion
        }

        private static void ViewElementAvaliacao(List<string> result)
        {
            Console.WriteLine("\nResultado\n");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void ViewElement(int nElement = 0)
        {
            var lista = new List<ITrade>();
            Console.WriteLine("Formato Esperado: Number Sector(Public ou Private) Date(mm/dd/yyyy)\n");

            for (int i = 0; i < nElement; i++)
            {
                // Coletar dados e Converter para Array
                var dados = ReadTradeInput().Split(' ');

                // Quantidade de Negociação
                var result = dados[0] + "0";
                double numeroNegociacoes = double.Parse(result);

                // Setor do Cliente
                string strSetorClient = dados[1];

                // Data do Próximo Pagamento
                DateTime dataPagamentoPendente = DateTimeUtil.ConvertStrInDateTime(dados[2]);

                lista.Add(new Trade(numeroNegociacoes, strSetorClient, dataPagamentoPendente));
            }

            _trades = lista;
        }

        private static string ReadTradeInput()
        {
            int countErros = 0;
            string outputValid = "";

            do
            {
                if (countErros > 0)
                {
                    Console.WriteLine("Entrada Inválida :-(\n");
                    Console.WriteLine("Formato Esperado: Number Sector(Public ou Private) Date(mm/dd/yyyy)\n");
                }
                
                outputValid = Console.ReadLine();
                countErros++;
            } while (Validade(outputValid) == false);

            return outputValid;
        }

        private static bool Validade(string outputValid)
        {
            var allValid = new List<bool>();

            try
            {
                var outputSplited = outputValid.Split(' ');

                if (outputSplited.Length != 3) return false;

                allValid.Add(Valid.Validade(outputSplited[0], EOutputConvert.Double));
                allValid.Add(Valid.Validade(outputSplited[1], EOutputConvert.String));
                allValid.Add(Valid.Validade(outputSplited[2], EOutputConvert.DateTime));

                if (outputSplited[1].Equals("Private") || outputSplited[1].Equals("Public"))
                {
                    allValid.Add(true);
                }
                else
                {
                    allValid.Add(false);
                }

                return allValid.All(x => x == true);
            }
            catch
            {
                return false;
            }
        }
    }
}
