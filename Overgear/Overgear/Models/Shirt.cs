using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Overgear.Models
{
    public class Shirt
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter the description of the item.")]
        public string Description { get; set; }
        public string Colour { get; set; }

        [Required(ErrorMessage = "Please enter the size of the item.")]
        public int Size { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter the quantity of the item.")]
        public int Quantity { get; set; }
    }
}
