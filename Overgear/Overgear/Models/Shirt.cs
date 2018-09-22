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
        public string Description { get; set; }
        public string Colour { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Size { get; set; }
        
        [Range(0, Int32.MaxValue)]
        public int Quantity { get; set; }
    }
}
