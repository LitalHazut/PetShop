using Microsoft.AspNetCore.Mvc;
using PetShop.Client.Models;
using PetShop.Service;
using PetShop.Service.Interfaces;

namespace PetShop.Client.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly ICommentService commentService;
        private readonly IRepositoryFactory repositoryFactory;

        public CatalogController()
        {
            this.repositoryFactory = new RepositoryFactory();
            this.animalService = new AnimalService(repositoryFactory.CreateAnimalRepo());
            this.commentService = new CommentService(repositoryFactory.CreateCommentRepo());
        }
        public IActionResult Index()
        {
            return View(animalService.GetAll());
        }

        public IActionResult Detalis(int id)
        {
            return View(new AnimalDetailsViewModel(animalService.GetById(id),commentService.GetByAnimalId(id))) ;
        }

    }
}
