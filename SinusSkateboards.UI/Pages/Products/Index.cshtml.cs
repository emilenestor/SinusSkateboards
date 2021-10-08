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

namespace SinusSkateboards.UI.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext context;
        [BindProperty(SupportsGet = true)]
        public List<ProductModel> ProductList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(SinusDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            ProductList = context.Products.ToList();
        }
        public void OnGetCategory(int id)
        {
            ProductList = context.Products.Where(x => x.CategoryId == id).ToList();
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

            return RedirectToPage("./Index");
        }
        public void OnPostSearch(string searchString)
        {
            if (SearchString != null)
            {
                ProductList = context.Products.Include(x => x.Category).Where(x => x.Title.ToUpper().Contains(SearchString.ToUpper()) || x.Category.Name.ToUpper().Contains(SearchString.ToUpper()) || x.Colour.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            else
            {
                ProductList = context.Products.ToList();
            }
        }
    }
}
