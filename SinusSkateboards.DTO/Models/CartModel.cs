using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinusSkateboards.DTO.Models
{
    public class CartModel
    {
        public List<CartProductModel> ProductsInCart { get; set; }
        public CartModel()
        {
            ProductsInCart = new List<CartProductModel>();
        }
    }
}
