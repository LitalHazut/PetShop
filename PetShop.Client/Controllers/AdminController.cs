using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Model;
using PetShop.Service;
using PetShop.Service.Interfaces;

namespace PetShop.Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        public AdminController(IAnimalService animalService, ICategoryService categoryService, ICommentService commentService)
        {
            _animalService = animalService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var Animaldisplay = _animalService.GetAll()
           .Include(a => a.Comments).Include(a => a.Category);

            var category = _categoryService.GetAll();
            ViewBag.GetCategory = category;

            return View(Animaldisplay);
        }

        [HttpPost]
        public IActionResult Index(int categoryId)
        {
            var category = _categoryService.GetAll();
            ViewBag.GetCategory = category;

            var animalsByCategory = _animalService.GetAnimalsByCategory(categoryId);

            return View(animalsByCategory);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var animal = await _animalService.GetAll()
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null) return NotFound();
            ViewBag.CommentsAnimal = _commentService.GetByAnimalId(animal.AnimalId);

            return View(animal);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("AnimalId,Name,Description,BirthDate,PhotoUrl,CategoryId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _animalService.Create(animal);

                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);

        }
        public IActionResult Edit(int id)
        {
            var animal = _animalService.Get(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AnimalId,Name,Description,BirthDate,PhotoUrl,CategoryId")] Animal animal)
        {
            if (id != animal.AnimalId)
                return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    _animalService.Update(animal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var animal = await _animalService.GetAll()
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);

            if (animal == null)
                return NotFound();

            return View(animal);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var animal = _animalService.Get(id);
            _animalService.Delete(animal.AnimalId);
            return RedirectToAction("Index");
        }

        private bool AnimalExists(int id)
        {
            return _animalService.GetAll().Any(e => e.AnimalId == id);
        }

        public ActionResult AddComment(Animal animal, [Bind("myComment")] string myComment)
        {
            if (myComment != null)
            {
                var Newcomment = new Comment { AnimalId = animal.AnimalId, Content = myComment };
                _commentService.Create(Newcomment);

            }
            return RedirectToAction("Details", new { id = animal.AnimalId });

        }

        public async Task<ActionResult> DeleteComment(int? id)
        {
            if (id == null) return NotFound();

            var comment = await _commentService.GetAll()
                .FirstOrDefaultAsync(c => c.CommentId == id);

            if (comment == null) return NotFound();
            _commentService.Delete(comment.CommentId);


            return RedirectToAction("Details", new { id = comment.AnimalId });
        }

        public ActionResult AddCategory([Bind("myCategory")] string myCategory)
        {
            if (myCategory != null)
            {
                var NewCategory = new Category { Name = myCategory };
                _categoryService.Create(NewCategory);

            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Name");

            return View();

        }

        
        public async Task<IActionResult> DeleteCategory(int? categoryId)
        {
            if (categoryId == null) return NotFound();
            var category = await _categoryService.GetAll()
               .FirstOrDefaultAsync(c => c.CategoryId == categoryId);

            if (category == null) return NotFound();
            _categoryService.Delete(category.CategoryId);


            return RedirectToAction("AddCategory");


        }

    }
}
