using DesafioCielo.Interface;
using DesafioCielo.Models;
using teste.Models;

namespace DesafioCielo.Services
{
    public class AddAdquirenteService : IAddAdquirenteService
    {
        public List<Adquirente> ListaAdquirentes = new();
        public List<Adquirente> CreateAquirente()
        {
            

            ListaAdquirentes.Add(new Adquirente

            {

               
                Nome = "Adquirente A",
                Taxas = new List<Taxa> {new Taxa {Bandeira = "Visa", Credito = 2.25M,
                Debito = 2.00M } ,new Taxa{Bandeira ="Master",Credito = 2.35M, Debito = 1.98M}}
            });

            ListaAdquirentes.Add(new Adquirente
            {
                
                Nome = "Adquirente B",
                Taxas = new List<Taxa> {new Taxa {Bandeira = "Visa", Credito = 2.50M,
                Debito = 2.08M } ,new Taxa{Bandeira ="Master",Credito = 2.65M, Debito = 1.75M}}
            });

            ListaAdquirentes.Add(new Adquirente
            {
                
                Nome = "Adquirente C",
                Taxas = new List<Taxa> {new Taxa {Bandeira = "Visa", Credito = 2.75M,
                Debito = 2.16M } ,new Taxa{Bandeira ="Master",Credito = 3.10M, Debito = 1.58M}}
            });

            return ListaAdquirentes;
        }

        public Transacao CalculaTransacao(Adquirente adquirente)
        {
            var adquirenteCalc = ListaAdquirentes.Find(x => x.Nome.ToLower().EndsWith(adquirente.Nome.ToLower()));
            var taxa = adquirenteCalc.Taxas.Find(x => x.Bandeira.ToLower().Equals(adquirente.Bandeira.ToLower()));
          
            decimal? valorLiquido = adquirente.Valor - (adquirente.Valor * (adquirente.Tipo.ToLower().Equals("credito") ? taxa.Credito : taxa.Debito));

            Transacao transacao = new();
            transacao.ValorLiquido = valorLiquido;

            return transacao;


        }
    }


}
