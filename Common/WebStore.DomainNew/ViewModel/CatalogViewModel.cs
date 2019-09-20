using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Filters;

namespace WebStore.ViewModel
{
    public class CatalogViewModel : ProductFilter
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
