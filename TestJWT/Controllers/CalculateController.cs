using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestJWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CalculateController : ControllerBase
    {
        [HttpPost]
        public IActionResult Sum([FromForm] int num1, [FromForm] int num2)
        {
            var result = num1 + num2;
            return Ok(result);
        }
    }
}
