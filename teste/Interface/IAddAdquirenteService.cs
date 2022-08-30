using DesafioCielo.Models;
using teste.Models;

namespace DesafioCielo.Interface
{
    public interface IAddAdquirenteService
    {
        List<Adquirente> CreateAquirente();
        Transacao CalculaTransacao(Adquirente adquirente);
    }
}
