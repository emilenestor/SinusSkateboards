using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly SinusDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EditModel(SinusDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        public List<CategoryModel> Categories { get; set; }
        [BindProperty]
        public int ChosenCategory { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            Categories = _context.Categories.ToList();

            if (ProductModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Photo != null)
            {
                //CHANGE PHOTO//

                //Get path to wwwroot/images/products
                string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");

                //Check if image dir exists
                //If not:Create image dir
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //Check if ProductModel has photo in image dir
                //If yes: remove that photo
                string file = Path.Combine(folder, ProductModel.ImagePath);
                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                }

                //Create unique filename for new photo

                //string guid = Guid.NewGuid().ToString();

                string uniqueFileName = String.Concat(Guid.NewGuid().ToString(), "-", ProductModel.Title.ToLower(), ".jpg");
                string uploadPath = Path.Combine(folder, uniqueFileName);

                //Upload new photo
                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
                //Update ProductModel with new PhotoPath
                ProductModel.ImagePath = uniqueFileName;
            }

            ProductModel.CategoryId = ChosenCategory;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(ProductModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductModelExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
