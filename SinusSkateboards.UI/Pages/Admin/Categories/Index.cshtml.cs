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
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext context;
        public List<CategoryModel> Categories { get; set; }

        public IndexModel(SinusDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Categories = context.Categories.ToList();
        }
    }
}
