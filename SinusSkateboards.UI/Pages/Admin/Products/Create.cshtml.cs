using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly SinusDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CreateModel(SinusDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context; 
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            Categories = _context.Categories.ToList();
            return Page();
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }
        [BindProperty]
        [Required]
        public IFormFile Photo { get; set; }
        public List<CategoryModel> Categories { get; set; }
        [BindProperty]
        public int ChosenCategory { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Photo != null)
            {
                //ADD PHOTO//

                //Get path to wwwroot/images/products
                string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");

                //Check if image dir exists
                //If not:Create image dir
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
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
                //Add ImagePath to ProductModel
                ProductModel.ImagePath = uniqueFileName;
            }

            ProductModel.CategoryId = ChosenCategory;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(ProductModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
