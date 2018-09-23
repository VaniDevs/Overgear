using System;
using System.ComponentModel.DataAnnotations;

namespace Overgear.Models
{
    public class Shoe
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the description of the item.")]
        public string Description { get; set; }

        [Range(5, 13, ErrorMessage = "Please enter the size of the item.")]
        public int Size { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter the quantity of the item.")]
        public int Quantity { get; set; }
    }
}
