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

namespace SinusSkateboards.UI.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext context;
        public CartModel Cart { get; set; } = new CartModel();
        public int CartCount { get; set; }
        public decimal TotalPrice { get; set; }
        public IndexModel(SinusDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Cart.ProductsInCart = new List<CartProductModel>();

            CartModel cart = new CartModel();

            string stringCart = HttpContext.Session.GetString("CookieCart");

            if (!String.IsNullOrEmpty(stringCart))
            {
                cart = JsonConvert.DeserializeObject<CartModel>(stringCart);
            }

            if (cart.ProductsInCart != null)
            {
                if (cart.ProductsInCart.Any())
                {
                    Cart = cart;
                    foreach (var cartProduct in cart.ProductsInCart)
                    {
                        CartCount += cartProduct.Quantity;
                    }
                    foreach (var cartProduct in cart.ProductsInCart)
                    {
                        TotalPrice += cartProduct.Quantity * cartProduct.Product.Price;
                    }
                }
            }
        }
        public IActionResult OnGetAddOne(int id)
        {
            ProductModel productToAdd = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            CartModel cart = new CartModel();

            string stringCart = HttpContext.Session.GetString("CookieCart");

            if (!String.IsNullOrEmpty(stringCart))
            {
                cart = JsonConvert.DeserializeObject<CartModel>(stringCart);
            }

            if (cart.ProductsInCart.Where(x => x.Product.Id == id).Any())
            {
                cart.ProductsInCart.FirstOrDefault(x => x.Product.Id == id).Quantity++;
            }

            stringCart = JsonConvert.SerializeObject(cart);

            HttpContext.Session.SetString("CookieCart", stringCart);

            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoveOne(int id)
        {
            ProductModel productToRemove = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            CartModel cart = new CartModel();

            string stringCart = HttpContext.Session.GetString("CookieCart");

            if (!String.IsNullOrEmpty(stringCart))
            {
                cart = JsonConvert.DeserializeObject<CartModel>(stringCart);
            }

            if (cart.ProductsInCart.Where(x => x.Product.Id == id).Any())
            {
                if (cart.ProductsInCart.FirstOrDefault(x => x.Product.Id == id).Quantity == 1)
                {
                    cart.ProductsInCart.Remove(cart.ProductsInCart.FirstOrDefault(x => x.Product.Id == id));
                }
                else
                {
                    cart.ProductsInCart.FirstOrDefault(x => x.Product.Id == id).Quantity--;
                }
            }

            stringCart = JsonConvert.SerializeObject(cart);

            HttpContext.Session.SetString("CookieCart", stringCart);

            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoveFromCart(int id)
        {
            ProductModel productToRemove = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            CartModel cart = new CartModel();

            string stringCart = HttpContext.Session.GetString("CookieCart");

            if (!String.IsNullOrEmpty(stringCart))
            {
                cart = JsonConvert.DeserializeObject<CartModel>(stringCart);
            }

            if (cart.ProductsInCart.Where(x => x.Product.Id == id).Any())
            {
                cart.ProductsInCart.Remove(cart.ProductsInCart.FirstOrDefault(x => x.Product.Id == id));
            }

            stringCart = JsonConvert.SerializeObject(cart);

            HttpContext.Session.SetString("CookieCart", stringCart);

            return RedirectToPage("./Index");
        }
    }
}
