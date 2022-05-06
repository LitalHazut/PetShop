using Microsoft.AspNetCore.Mvc;

namespace PetShop.Client.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
