using Microsoft.AspNetCore.Mvc;

namespace NextNormal.API.Controllers
{
    public class AuthViewController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
