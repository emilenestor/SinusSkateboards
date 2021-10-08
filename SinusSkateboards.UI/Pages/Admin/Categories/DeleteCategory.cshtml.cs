using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Admin.Categories
{
    public class DeleteCategoryModel : PageModel
    {
        private readonly SinusDbContext context;
        public CategoryModel Category { get; set; }
        public List<ProductModel> Products { get; set; }
        public DeleteCategoryModel(SinusDbContext _context)
        {
            context = _context;
        }
        public void OnGet(int id)
        {
            Category = context.Categories.FirstOrDefault(x => x.Id == id);
            Products = context.Products.Where(x => x.CategoryId == id).ToList();
        }
        public IActionResult OnGetDelete(int id)
        {
            var category = context.Categories.Find(id);

            context.Categories.Remove(category);

            context.SaveChanges();

            return RedirectToPage("/Admin/Categories/Index");
        }
    }
}
