using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Admin.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly SinusDbContext context;
        public OrderModel Order { get; set; }
        public DetailsModel(SinusDbContext context)
        {
            this.context = context;
        }
        public void OnGet(int id)
        {
            Order = context.Orders.Include(x => x.Customer).Include(x => x.OrderedProducts).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
        }
    }
}
