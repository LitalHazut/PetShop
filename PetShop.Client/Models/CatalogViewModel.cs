using PetShop.Data.Model;

namespace PetShop.Client.Models
{
    public class CatalogViewModel
    {
        public IEnumerable<Animal> AnimalList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public CatalogViewModel(IEnumerable<Animal> animalList, IEnumerable<Category> categoryList)
        {
            AnimalList=animalList;
            CategoryList=categoryList;  
        }
    }
}
