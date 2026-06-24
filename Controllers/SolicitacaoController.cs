using Microsoft.AspNetCore.Mvc;
using project_api_reciclaAi.Services.Solicitacao;

namespace project_api_reciclaAi.Controllers
{
    [Route("v1/solicitação")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService _service;

        public SolicitacaoController(ISolicitacaoService service)
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

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(int clienteId)
        {
            var result = await _service.GetByClienteAsync(clienteId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SolicitacaoRequestDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] SolicitacaoStatusUpdateDto dto)
        {
            var result = await _service.UpdateStatusAsync(id, dto);
            return Ok(result);
        }

        [HttpPatch("{id}/atribuir-equipe/{equipeId}")]
        public async Task<IActionResult> AtribuirEquipe(int id, int equipeId)
        {
            var result = await _service.AtribuirEquipeAsync(id, equipeId);
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
