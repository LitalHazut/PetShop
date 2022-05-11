using Microsoft.AspNetCore.Mvc;
using PetShop.Client.Models;
using PetShop.Service.Interfaces;
using System.Diagnostics;

namespace PetShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimalService _animalService;

        public HomeController(ILogger<HomeController> logger, IAnimalService animalService)
        {
            _logger = logger;
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            var topAnimals = _animalService.GetTopThreeAnimals();
            return View(topAnimals);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}