using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SinusSkateboards.DAL;
using SinusSkateboards.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SinusSkateboards.UI.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext context;
        public CartModel Cart { get; set; } = new CartModel();
        public int CartCount { get; set; }
        public decimal TotalPrice { get; set; }
        [BindProperty]
        public CustomerModel Customer { get; set; }
        public DateTime DateTimeNow { get; set; }
        public IndexModel(SinusDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet()
        {
            Cart.ProductsInCart = new List<CartProductModel>();

            CartModel cart = LoadCart();

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
                else
                {
                    return RedirectToPage("/Cart/Index");
                }
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            OrderModel newOrder = new OrderModel();

            newOrder.Customer = Customer;

            DateTimeNow = DateTime.Now;
            newOrder.OrderDate = DateTimeNow;

            newOrder.OrderedProducts = new List<OrderDetailsModel>();

            foreach (var product in LoadCart().ProductsInCart)
            {
                OrderDetailsModel odm = new OrderDetailsModel() { ProductId = product.Product.Id, Quantity = product.Quantity };
                newOrder.OrderedProducts.Add(odm);
            }

            context.Orders.Add(newOrder);

            context.SaveChanges();

            AddOrderCookie(newOrder.Id);

            RemoveCartCookie();

            return RedirectToPage("/Checkout/Success");
        }

        private void RemoveCartCookie()
        {
            HttpContext.Session.SetString("CookieCart", "");
        }

        public CartModel LoadCart()
        {
            Cart.ProductsInCart = new List<CartProductModel>();

            CartModel cart = new CartModel();

            string stringCart = HttpContext.Session.GetString("CookieCart");

            if (!String.IsNullOrEmpty(stringCart))
            {
                cart = JsonConvert.DeserializeObject<CartModel>(stringCart);
            }

            return cart;
        }
        public void AddOrderCookie(int orderId)
        {
            OrderModel orderToAdd = context.Orders.Include(x => x.Customer).Include(x => x.OrderedProducts).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == orderId);

            string stringOrder = HttpContext.Session.GetString("LatestOrder");

            stringOrder = JsonConvert.SerializeObject(orderToAdd, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );

            HttpContext.Session.SetString("LatestOrder", stringOrder);
        }
    }
}
