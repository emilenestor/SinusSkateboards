using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext _context;

        public IndexModel(SinusDbContext context)
        {
            _context = context;
        }

        public IList<ProductModel> ProductModel { get;set; }

        public async Task OnGetAsync()
        {
            ProductModel = await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
