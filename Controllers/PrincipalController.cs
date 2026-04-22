using Microsoft.AspNetCore.Mvc;

namespace project_api_reciclaAi.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { api = "ApiReciclaAi", status = "up" });
        }
    }
}
