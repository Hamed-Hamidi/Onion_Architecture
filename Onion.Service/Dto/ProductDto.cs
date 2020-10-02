using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Onion.Service.Dto
{
   public class ProductDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string Name { get; set; }

 
        public string Description { get; set; }

      
        [Required]

        public double Price { get; set; }
    }
}
