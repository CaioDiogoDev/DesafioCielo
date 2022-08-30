using DesafioCielo.Models;
using DesafioCielo.Services;
using Microsoft.AspNetCore.Mvc;
using teste.Models;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartoesController : ControllerBase
    {

        private readonly AddAdquirenteService _addAdquirenteService;

        public CartoesController(AddAdquirenteService addAdquirenteService)
        {
            _addAdquirenteService = addAdquirenteService;

        }

        [HttpGet(Name = "/mdr")]
        public ActionResult<Adquirente> Get()
        {


            var createAdquirente = _addAdquirenteService.CreateAquirente();

            return Ok(createAdquirente);

        }

        [HttpPost(Name = "/transaction")]

        public ActionResult<Transacao> Post([FromBody] Adquirente adquirente)
        {
            var transacao = _addAdquirenteService.CalculaTransacao(adquirente);
            return Ok(transacao);
        }

    }
}