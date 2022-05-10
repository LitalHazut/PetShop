using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Model;
using PetShop.Service.Interfaces;

namespace PetShop.Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;
        public AdminController(IAnimalService animalService, ICategoryService categoryService)
        {
            _animalService = animalService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var petShopDataContext = _animalService.GetAll()
           .Include(a => a.Category);
            return View(petShopDataContext);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var animal = await _animalService.GetAll()
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
                return NotFound();

            return View(animal);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId,Name,Description,BirthDate,PhotoUrl,CategoryId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _animalService.Create(animal);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);

        }
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(int id, [Bind("AnimalId,Name,Description,BirthDate,PhotoUrl,CategoryId")] Animal animal)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = _animalService.Get(id);
            _animalService.Delete(animal.AnimalId);
            return RedirectToAction("Index");
        }

        private bool AnimalExists(int id)
        {
            return _animalService.GetAll().Any(e => e.AnimalId == id);
        }

    }
}
