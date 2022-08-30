using DesafioCielo.Interface;
using DesafioCielo.Models;
using DesafioCielo.Models.Dto;


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
                if (adquirenteDto.Nome != "")
                {
                    var adquirenteCalc = listaAdquirentes.Find(x => x.Adquirente.ToLower().EndsWith(adquirenteDto.Nome.ToLower()));

                    var taxa = adquirenteCalc.Taxas.Find(x => x.Bandeira.ToLower().Equals(adquirenteDto.Bandeira.ToLower()));

                    decimal? valorLiquido = adquirenteDto.Valor - (adquirenteDto.Valor * (adquirenteDto.Tipo.ToLower().Equals("credito") ? taxa.Credito / 100 : taxa.Debito / 100));

                    transacao.ValorLiquido = valorLiquido;

                    transacao.ResponseM = "Calculo realizado com sucesso!";
                }
                else
                {
                    transacao.ValorLiquido = 0; 
                    transacao.ResponseM = "Adquirente não encontrado!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return transacao;
        }
        #endregion 
    }
}
