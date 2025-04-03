using Menu.Repo;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        //1.Import the context
        private readonly MenuContext _context;
        //2.Create a Contructor for context, context helps you interact with the database
        public MenuController(MenuContext context)
        {
            _context = context;
        }
        //3. Create Index to return Dishes value into the View
        public async Task<IActionResult> Index()
        {
            return View( await _context.Dishes.ToListAsync());
        }
        //3. Create Index to return the Details value into the View
        public async Task< IActionResult> Details(int? id)
        {
            //Loop trouh the context of dishes the element of the ID
            var dish = await _context.Ingredients
                .Include(di => di.DishIngredients)
                .ThenInclude(i =>i.Ingredient)
                .FirstOrDefaultAsync( x => x.Id ==id );

            if (dish == null)
            {
                return NotFound();
            }
                return View(dish);
        }
        
    }
}
