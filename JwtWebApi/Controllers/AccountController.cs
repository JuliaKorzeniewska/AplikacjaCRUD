using Microsoft.AspNetCore.Mvc;
using JwtWebApi;
namespace JwtWebApi.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Verify(User user)
        {
            return View();
        }
    }
}
