using Microsoft.AspNetCore.Mvc;
using project_api_reciclaAi.Dtos.Autenticacao;
using project_api_reciclaAi.Services.Autenticacao;

namespace project_api_reciclaAi.Controllers
{
    [Route("v1/autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _service;

        public AutenticacaoController(IAutenticacaoService service)
        {
            _service = service;
        }

        [HttpPost("gerar-chave")]
        public async Task<IActionResult> GerarChave([FromBody] GerarChaveRequestDto dto)
        {
            var result = await _service.GerarChaveAsync(dto);
            return Ok(result);
        }
    }
}
