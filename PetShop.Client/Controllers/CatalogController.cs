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
            var petShopDataContext = animalService.GetAll()
          .Include(a => a.Category);
            return View(petShopDataContext);

        }

        //public IActionResult Detalis(int id)
        //{
        //    return View(new AnimalDetailsViewModel(animalService.Get(id), commentService.GetByAnimalId(id))); ;
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var animal = await animalService.GetAll()
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
                return NotFound();

            return View(animal);
        }

       
        [HttpPost]
        public ActionResult AddComment([Bind("Content,AnimalId")] Comment comment, Animal animal)
        {
            if (comment.Content != null)
            {
                var com = new Comment { AnimalId = animal.AnimalId };
                commentService.Create(com);
                animalService.Update(animal);
                List<Comment> commentList = commentService.GetAll().Where(cmId => cmId.AnimalId == comment.AnimalId).ToList();
            }
            return RedirectToAction("Detalis");









        }



    }
}
