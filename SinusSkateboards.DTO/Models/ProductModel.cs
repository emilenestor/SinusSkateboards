using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinusSkateboards.DTO.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Colour { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        [Required]
        [Column(TypeName = "decimal(19,2)")]
        public decimal Price { get; set; }
    }
}
