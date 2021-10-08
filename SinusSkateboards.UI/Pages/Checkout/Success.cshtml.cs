using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;

namespace SinusSkateboards.UI.Pages.Checkout
{
    public class SuccessModel : PageModel
    {
        private readonly SinusDbContext context;

        public OrderModel Order { get; set; }
        public SuccessModel(SinusDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            OrderModel order = new OrderModel();

            string stringOrder = HttpContext.Session.GetString("LatestOrder");

            if (!String.IsNullOrEmpty(stringOrder))
            {
                order = JsonConvert.DeserializeObject<OrderModel>(stringOrder);
            }

            if (order != null)
            {
                    Order = order;
            }
        }
    }
}
