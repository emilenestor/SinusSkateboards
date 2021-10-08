using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Admin.Orders
{
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext context;
        public List<OrderModel> Orders { get; set; }

        public IndexModel(SinusDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Orders = context.Orders.ToList();
        }
    }
}
