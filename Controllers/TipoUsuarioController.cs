using Microsoft.AspNetCore.Mvc;
using project_api_reciclaAi.Services.TipoUsuario;

namespace project_api_reciclaAi.Controllers
{
    [Route("v1/tipo-usuario")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _service;

        public TipoUsuarioController(ITipoUsuarioService service)
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
    }
}
