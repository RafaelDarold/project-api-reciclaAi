using Microsoft.AspNetCore.Mvc;
using project_api_reciclaAi.Services.Coleta;

namespace project_api_reciclaAi.Controllers
{
    [Route("/coletas")]
    [ApiController]
    public class ColetaController : ControllerBase
    {
        private readonly IColetaService _service;

        public ColetaController(IColetaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("solicitacao/{solicitacaoId}")]
        public async Task<IActionResult> GetBySolicitacao(int solicitacaoId)
        {
            var result = await _service.GetBySolicitacaoAsync(solicitacaoId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColetaRequestDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPatch("{id}/finalizar")]
        public async Task<IActionResult> Finalizar(int id)
        {
            var result = await _service.FinalizarAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}