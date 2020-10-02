using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Onion.Data.Common;

namespace Onion.Data.Modes.Products
{
   public class Product : BaseEntity
    {
      

        [Required]
        public string Name { get; set; }

     
        public string Description { get; set; }

    
        [Required]

        public double Price { get; set; }
    }
}
