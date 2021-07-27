
using Churrasco.Domain.Entities;
using Churrasco.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Churrasco.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("")]
    public class ParticipanteController : ControllerBase
    {
        private IParticipanteService _participanteService;

        public ParticipanteController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }



        [HttpPost("incluir-participante")]
        public IActionResult AdicionarParticipante([FromBody] Participante request)
        {

            var response = _participanteService.AdicionarParticipante(request);

            if (response != string.Empty)
            {
                return BadRequest(response);
            }
            return Created("Cadastrado com Sucesso!",request);

        }

        [HttpPost("editar-participante")]
        public IActionResult EditarParticipante([FromBody] Participante request)
        {

            _participanteService.EditarParticipante(request);
            return Ok("Atualizado com Sucesso!");

        }
        [HttpDelete("remover-participante/{id}")]
        public ActionResult RemoverParticipante(int id)
        {
            var obj = _participanteService.ObterPorIdParticipante(id);
            if (obj == null)
            {
                return NotFound("Não foi possível encontrar o Participante!");
            }
            _participanteService.RemoverParticipante(id);
            return Ok("Removido com Sucesso!");

        }
    }
}
