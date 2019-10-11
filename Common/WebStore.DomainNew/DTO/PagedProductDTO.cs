using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.DTO
{
    public class PagedProductDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }

        public int TotalCount { get; set; }
    }
}
