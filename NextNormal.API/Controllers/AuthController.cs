using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NextNormal.API.Models;
using NextNormal.Entity;

namespace NextNormal.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(
        UserManager<AppUser> usermanager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO request, CancellationToken cancellationToken)
        {
            AppUser appuser = new()
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            IdentityResult result = await usermanager.CreateAsync(appuser, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
                return NoContent();
        }
    }
}
