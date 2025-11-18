using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO request, CancellationToken cancellationToken)
        {
            AppUser? appuser = await usermanager.FindByIdAsync(request.Id.ToString());
            if (appuser is null)
            {
                return BadRequest(new { Message = "kullanıcı bulunamadı" });
            }
            IdentityResult identityResult = await usermanager.ChangePasswordAsync(appuser, request.CurrentPassword, request.NewPassword);
            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors.Select(s => s.Description + s.Code));
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> ForgetPassword(string email, CancellationToken cancellationtoken)
        {
            AppUser? appuser = await usermanager.FindByEmailAsync(email);
            if (appuser is null)
            {
                return BadRequest(new { Message = "kullanıcı bulunamadı" });
            }
            string token = await usermanager.GeneratePasswordResetTokenAsync(appuser);
            return Ok(new { Token = token });
            //yeni tokenımızı aldık
        }
        [HttpPost]
        public async Task<IActionResult> ChangePasswordWithToken(ChangePassordWithTokenDTO request, CancellationToken cancellationtoken)
        {
            AppUser? appuser = await usermanager.FindByEmailAsync(request.Email);
            if (appuser is null)
            {
                return BadRequest(new { Message = "kullanıcı bulunamadı" });
            }
            IdentityResult result = await usermanager.ResetPasswordAsync(appuser, request.newToken, request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(s => s.Description));

            }
            return NoContent();

        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginDTO request, CancellationToken cancellationToken)
        {
            AppUser? appuser = await usermanager.FindByEmailAsync(request.Email);
            if(appuser is null)
            {
                return BadRequest(new { Message = "kullanıcı bulunamadı" });
            }
            bool result=await usermanager.CheckPasswordAsync(appuser,request.Password);
            if (!result)
            {
                return BadRequest(new { Message = "parola hatalı" });
            }
            //if (appuser.EmailConfirmed == false)
            //{
            //    return BadRequest(new { Message = "Email doğrulaması gerekli" });
            //}
            return Ok(new { Token = "token" });
        }

    

    }
}
