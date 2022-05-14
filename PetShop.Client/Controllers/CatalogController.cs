using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Client.Models;
using PetShop.Data.Model;
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
            var Animaldisplay= animalService.GetAll()
           .Include(a => a.Comments).Include(a => a.Category);

            var category = categoryService.GetAll();
            ViewBag.GetCategory = category;

            return View(Animaldisplay);

        }

        [HttpPost]
        public IActionResult Index(int categoryId)
        {
            var category = categoryService.GetAll();
            ViewBag.GetCategory = category;

            var animalsByCategory = animalService.GetAnimalsByCategory(categoryId);

            return View(animalsByCategory);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var animal = await animalService.GetAll()
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
                return NotFound();
            ViewBag.CommentsAnimal = commentService.GetByAnimalId(animal.AnimalId);

            return View(animal);
        }

     

    }
}
