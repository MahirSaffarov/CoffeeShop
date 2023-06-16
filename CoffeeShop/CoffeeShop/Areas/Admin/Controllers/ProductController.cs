using CoffeeShop.Areas.Admin;
using CoffeeShop.DAL;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class ProductController : Controller
    {
        public readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;


        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products= await _context.Products.Include(c=>c.ProductAromas).ThenInclude(c=>c.Aroma).ToListAsync();
       

            return View(products);
        }
        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null) return BadRequest();
            var productDb = await _context.Products.FirstOrDefaultAsync(p=>p.Id==Id);
            if (productDb == null) return NotFound();
           
            return View(productDb);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var aromas = _context.Aromas.ToList();
            var aromasList = new SelectList(aromas, "Id","Name");
            ViewBag.aromas = aromasList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            
            Product pr = new()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model
                .Description,
                Image = model.Image
                
            };
            await _context.Products.AddAsync(pr);
            await _context.SaveChangesAsync();
            foreach (var id in model.AromaId)
            {
                ProductAroma prA = new()
                {
                    Product = pr,
                    Aroma = await _context.Aromas.FirstOrDefaultAsync(m=>m.Id == id),
                    ProductId = pr.Id,
                    AromaId = id
                };
              await  _context.ProductAromas.AddAsync(prA);
                await _context.SaveChangesAsync();
            }
          
            return RedirectToAction(nameof(Index));
        }
    }
}
