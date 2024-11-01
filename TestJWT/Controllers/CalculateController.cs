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
            return Ok(num1+num2);
        }
    }
}
