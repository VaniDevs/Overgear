using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overgear.Models
{
    public class Request
    {


        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        // Use dropdown instead of text box
        public List<Item> Items { get; set; }

        public string ItemType { get; set; }
        public int Quantity { get; set; }

    }
}
