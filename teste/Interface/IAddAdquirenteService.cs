using DesafioCielo.Models;
using DesafioCielo.Models.Dto;

namespace DesafioCielo.Interface
{
    public interface IAddAdquirenteService
    {
        List<AdquirenteM> CreateAquirente();
        Transacao CalculaTransacao(AdquirenteM adquirentes, AdquirenteDto adquirenteDto);
    }
}
