using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oninon.Web.Services;

namespace Onion.Web.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
