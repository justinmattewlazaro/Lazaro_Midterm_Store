using Lazaro_Midterm_Store.Data;
using Lazaro_Midterm_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lazaro_Midterm_Store.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display all products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Add sample products to the database
        public async Task<IActionResult> AddSampleProducts()
        {
            if (!await _context.Products.AnyAsync())
            {
                _context.Products.AddRange(
                    new Product
                    {
                        Name = "Nike Air Max",
                        Description = "Comfortable everyday sneakers",
                        Price = 4500,
                        Category = "Shoes"
                    },
                    new Product
                    {
                        Name = "Adidas Hoodie",
                        Description = "Comfortable casual hoodie",
                        Price = 2500,
                        Category = "Clothing"
                    },
                    new Product
                    {
                        Name = "Puma Backpack",
                        Description = "Durable backpack for everyday use",
                        Price = 1800,
                        Category = "Bags"
                    }
                );

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}