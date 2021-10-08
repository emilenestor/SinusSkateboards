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

namespace SinusSkateboards.UI.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext context;
        public ProductModel Product { get; set; }
        public bool HasOtherColours { get; set; } = false;
        public List<ProductModel> OtherColours { get; set; }
        public IndexModel(SinusDbContext context)
        {
            this.context = context;
        }
        public void OnGet(int id)
        {
            Product = context.Products.FirstOrDefault(x => x.Id == id);
            if (context.Products.Where(x => x.Title == Product.Title).ToList().Count > 1)
            {
                HasOtherColours = true;
                OtherColours = context.Products.Where(x => x.Title == Product.Title && x.Id != Product.Id).ToList();
            }
        }
        public IActionResult OnGetAddToCart(int id)
        {
            ProductModel productToAdd = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            CartModel cart = new CartModel();

            string stringCart = HttpContext.Session.GetString("CookieCart");

            if (!String.IsNullOrEmpty(stringCart))
            {
                cart = JsonConvert.DeserializeObject<CartModel>(stringCart);
            }

            if (!cart.ProductsInCart.Where(x => x.Product.Id == id).Any())
            {
                cart.ProductsInCart.Add(new CartProductModel() { Product = productToAdd, Quantity = 1 });
            }
            else
            {
                cart.ProductsInCart.FirstOrDefault(x => x.Product.Id == id).Quantity++;
            }

            stringCart = JsonConvert.SerializeObject(cart);

            HttpContext.Session.SetString("CookieCart", stringCart);

            return RedirectToPage("./Index", new { id = id });
        }
    }
}
