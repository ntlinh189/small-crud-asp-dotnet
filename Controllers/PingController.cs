using Microsoft.AspNetCore.Mvc;

namespace small_crud_asp_dotnet.Controllers;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
}