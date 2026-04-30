using Microsoft.AspNetCore.Mvc;
using project_api_reciclaAi.Services.EquipeColeta;

namespace project_api_reciclaAi.Controllers
{
    [Route("/equipe-coleta")]
    [ApiController]
    public class EquipeColetaController : ControllerBase
    {
        private readonly IEquipeColetaService _service;

        public EquipeColetaController(IEquipeColetaService service)
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

        [HttpGet("empresa/{empresaId}")]
        public async Task<IActionResult> GetByEmpresa(int empresaId)
        {
            var result = await _service.GetByEmpresaAsync(empresaId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipeColetaRequestDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EquipeColetaRequestDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
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