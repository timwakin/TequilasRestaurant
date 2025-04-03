using Microsoft.AspNetCore.Mvc;
using TequilasRestaurant.Data;
using TequilasRestaurant.Models;

namespace TequilasRestaurant.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredients; 

        public IngredientController(ApplicationDbContext context)
        {
            ingredients = new Repository<Ingredient>(context); 
        }

        public async Task<IActionResult> Index()
        {
            return View(await ingredients.GetAllAsync() );
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() {Includes = "ProductIngredients.Product" })); 
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Ingredient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IndregientId, Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredients.AddAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        //Ingredient/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient> { Includes = "ProductIngredients.Product" })); 
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Ingredient ingredient)
        {   
            await ingredients.DeleteAsync(ingredient.IngredientId);
            return RedirectToAction("Index");  
        }



    }
}
