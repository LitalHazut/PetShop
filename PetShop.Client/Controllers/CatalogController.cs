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
        private readonly ICategoryService categoryService;
        private readonly IRepositoryFactory repositoryFactory;

        public CatalogController()
        {
            this.repositoryFactory = new RepositoryFactory();
            this.animalService = new AnimalService(repositoryFactory.CreateAnimalRepo());

            this.categoryService = new CategoryService(repositoryFactory.CreateCategoryRepo());
            this.commentService = new CommentService(repositoryFactory.CreateCommentRepo());
        }
        public IActionResult Index()
        {
            return View(new CatalogViewModel(animalService.GetAll(),categoryService.GetAll()));
        }

        public IActionResult Detalis(int id)
        {
            return View(new AnimalDetailsViewModel(animalService.Get(id), commentService.GetByAnimalId(id))); ;
        }

    }
}
