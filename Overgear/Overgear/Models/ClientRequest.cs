using System;
using System.ComponentModel.DataAnnotations;

namespace Overgear.Models
{
    public class ClientRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Size { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Quantity { get; set; }
    }
}
