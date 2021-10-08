using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        private readonly SinusSkateboards.DAL.SinusDbContext _context;

        public DetailsModel(SinusSkateboards.DAL.SinusDbContext context)
        {
            _context = context;
        }

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
    }
}
