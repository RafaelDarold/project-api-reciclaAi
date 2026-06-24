using Microsoft.AspNetCore.Mvc;
using project_api_reciclaAi.Services.Avaliacao;

namespace project_api_reciclaAi.Controllers
{
    [Route("v1/avaliação")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _service;

        public AvaliacaoController(IAvaliacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQueryDto pagination)
        {
            var result = await _service.GetAllAsync(pagination);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("coleta/{coletaId}")]
        public async Task<IActionResult> GetByColeta(int coletaId, [FromQuery] PaginationQueryDto pagination)
        {
            var result = await _service.GetByColetaAsync(coletaId, pagination);
            return Ok(result);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(int clienteId, [FromQuery] PaginationQueryDto pagination)
        {
            var result = await _service.GetByClienteAsync(clienteId, pagination);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AvaliacaoRequestDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
