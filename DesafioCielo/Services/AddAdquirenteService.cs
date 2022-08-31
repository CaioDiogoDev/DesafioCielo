using DesafioCielo.Interface;
using DesafioCielo.Models;
using DesafioCielo.Models.Dto;
using System.Globalization;

namespace DesafioCielo.Services
{
    public class AddAdquirenteService : IAddAdquirenteService
    {
        #region Cria Adquirentes 
        public List<AdquirenteM> ListaAdquirentes = new();
        public List<AdquirenteM> CreateAquirente()
        {
            ListaAdquirentes.Add(new AdquirenteM
            {
                Adquirente = "Adquirente A",
                Taxas = new List<Taxa> {new Taxa {Bandeira = "Visa", Credito = 2.25M,
                Debito = 2.00M } ,new Taxa{Bandeira ="Master",Credito = 2.35M, Debito = 1.98M}}
            });

            ListaAdquirentes.Add(new AdquirenteM
            {
                Adquirente = "Adquirente B",
                Taxas = new List<Taxa> {new Taxa {Bandeira = "Visa", Credito = 2.50M,
                Debito = 2.08M } ,new Taxa{Bandeira ="Master",Credito = 2.65M, Debito = 1.75M}}
            });

            ListaAdquirentes.Add(new AdquirenteM
            {
                Adquirente = "Adquirente C",
                Taxas = new List<Taxa> {new Taxa {Bandeira = "Visa", Credito = 2.75M,
                Debito = 2.16M } ,new Taxa{Bandeira ="Master",Credito = 3.10M, Debito = 1.58M}}
            });

            return ListaAdquirentes;
        }
        #endregion

        #region Calcula Transacao 
        public Transacao CalculaTransacao(AdquirenteM adquirentes, AdquirenteDto adquirenteDto)
        {
            var listaAdquirentes = CreateAquirente();

            Transacao transacao = new();


            try
            {
                var adquirenteCalc = listaAdquirentes.Find(x => x.Adquirente.ToLower().EndsWith(adquirenteDto.Adquirente.ToLower()));


                if (adquirenteCalc != null)
                {
                    var taxa = adquirenteCalc.Taxas.Find(x => x.Bandeira.ToLower().Equals(adquirenteDto.Bandeira.ToLower()));
                    if (taxa == null)
                    {
                        transacao.ValorLiquido = 0;
                        transacao.Mensagem = "Bandeira não encontrada!";
                        return transacao;
                    }

                    if (adquirenteDto.Tipo.ToLower() != "credito" && adquirenteDto.Tipo.ToLower() != "debito")
                    {
                        transacao.ValorLiquido = 0;
                        transacao.Mensagem = "Forma de pagamento não encontrada!";
                        return transacao;
                    }
                   
                    decimal? valorLiquido = adquirenteDto.Valor - ObterTaxa(adquirenteDto.Tipo, taxa, adquirenteDto.Valor);

                    transacao.ValorLiquido = Math.Round((decimal)valorLiquido, 2); 
                  
                    transacao.Mensagem = "Transação realizada com sucesso!";
                }
                else
                {
                    transacao.ValorLiquido = 0;
                    transacao.Mensagem = "Adquirente não encontrado!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return transacao;
        }

        private decimal ObterTaxa(string tipo, Taxa taxa, decimal? valor)
        { 
            return tipo.ToLower() == "credito"  ? (decimal)((taxa.Credito * valor) / 100) : (decimal)((taxa.Debito * valor) / 100);
        }
          
        #endregion 
    }
}
