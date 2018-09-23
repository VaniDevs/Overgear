using System;
using System.ComponentModel.DataAnnotations;

namespace Overgear.Models
{
    public class Boot
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the description of the item.")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Please enter the colour of the item.")]
        public string Colour { get; set; }

        [Range(5, 13, ErrorMessage = "Please enter the size of the item.")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Please enter the quantity of the item.")]
        //[Range(1, Int32.MaxValue, ErrorMessage = "Please enter the correct quantity of the item.")]
        public int Quantity { get; set; }
    }
}
