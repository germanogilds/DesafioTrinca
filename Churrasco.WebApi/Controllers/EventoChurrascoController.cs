
using Churrasco.Domain.Entities;
using Churrasco.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Churrasco.WebApi.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("")]
    public class EventoChurrascoController : ControllerBase
    {
        private IEventoChurrascoService _eventoChurrascoService;

        public EventoChurrascoController(IEventoChurrascoService eventoChurrascoService)
        {
            _eventoChurrascoService = eventoChurrascoService;
        }

        [HttpGet]
        [Route("obter-churrascos")]
        public IActionResult ObterEventosChurrascos()
        {
            var obj = _eventoChurrascoService.ObterEventosChurrascos();
            if (obj == null)
            {
                return NotFound("Não existe Churrasco cadastrado!");
            }
            return Ok(obj);

        }

        [HttpGet]
        [Route("obter-churrasco-detalhe/{id}")]
        public IActionResult ObterDetalheEventoChurrasco(int id)
        {

            var obj = _eventoChurrascoService.ObterDetalheEventoChurrasco(id);
            if (obj==null)
            {
                return NotFound("Não foi possível encontrar o Churrasco!");
            }
            return Ok(obj);

        }

        [HttpGet]
        [Route("obter-churrasco/{id}")]
        public IActionResult ObterPorIdEventoChurrasco(int id)
        {

            var obj = _eventoChurrascoService.ObterPorIdEventoChurrasco(id);
            if (obj == null)
            {
                return NotFound("Não foi possível encontrar o Churrasco!");
            }
            return Ok(obj);

        }
        [HttpPost("incluir-churrasco")]
        public IActionResult AdicionarEventoChurrasco([FromBody] EventoChurrasco request)
        {

            _eventoChurrascoService.AdicionarEventoChurrasco(request);
            return Created("Cadastrado com Sucesso!", request);

        }

        [HttpPut("editar-churrasco")]
        public IActionResult EditarEventoChurrasco([FromBody] EventoChurrasco request)
        {

            _eventoChurrascoService.EditarEventoChurrasco(request);
            return Ok("Atualizado com Sucesso!");

        }
        [HttpDelete("remover-churrasco")]
        public ActionResult RemoverEventoChurrasco(int id)
        {

            _eventoChurrascoService.RemoverEventoChurrasco(id);
            return Ok("Removido com Sucesso!");

        }

    }
}
