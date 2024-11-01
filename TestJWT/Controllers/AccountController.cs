using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestJWT.Models;

namespace TestJWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var jWTAuthorizationManager = new JWTAuthorizationManager();
            var res = jWTAuthorizationManager.Authenticate(model.UserName, model.Password);

            if (res == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
