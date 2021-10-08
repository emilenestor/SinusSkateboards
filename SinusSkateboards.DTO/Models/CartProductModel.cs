using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinusSkateboards.DTO.Models
{
    public class CartProductModel
    {
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
