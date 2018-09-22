using System;
using System.ComponentModel.DataAnnotations;

namespace Overgear.Models
{
    public class Gloves
    {
        public int ID { get; set; }
        public string Description { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Size { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Quantity { get; set; }
    }
}
