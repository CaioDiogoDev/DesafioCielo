using DesafioCielo.Interface;
using DesafioCielo.Models;
using DesafioCielo.Models.Dto;
using Microsoft.AspNetCore.Mvc;


namespace DesafioCielo.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CartoesController : ControllerBase
    {
        private readonly IAddAdquirenteService _addAdquirenteService;

        public CartoesController(IAddAdquirenteService addAdquirenteService)
        {
            _addAdquirenteService = addAdquirenteService;
        }

        [HttpGet("/mdr")]
        public ActionResult<AdquirenteM> Get()
        {
            var createAdquirente = _addAdquirenteService.CreateAquirente();

            return Ok(createAdquirente);
        }

        [HttpPost("/transaction")]
        public ActionResult<Transacao> Post([FromBody] AdquirenteDto adquirenteDto)
        {
            AdquirenteM adquirentes = new();
            var transacao = _addAdquirenteService.CalculaTransacao(adquirentes, adquirenteDto);

            if (transacao.ValorLiquido == 0)
                return BadRequest(transacao.Mensagem);

            return Ok(transacao);
        }
    }
}