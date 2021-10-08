using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly SinusDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public DeleteModel(SinusDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (ProductModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.Products.FindAsync(id);

            if (ProductModel != null)
            {
                _context.Products.Remove(ProductModel);
                await _context.SaveChangesAsync();
            }

            //DELETE PHOTO//

            //Get path to wwwroot/images
            string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");

            //Check if image dir exists
            //If not:Create image dir
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //Check if Product has photo in image dir
            //If yes: remove that photo
            string file = Path.Combine(folder, ProductModel.ImagePath);
            if (System.IO.File.Exists(file))
            {
                System.IO.File.Delete(file);
            }

            return RedirectToPage("./Index");
        }
    }
}
