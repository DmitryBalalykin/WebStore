using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Filters;
using WebStore.DomainNew.ViewModel;

namespace WebStore.ViewModel
{
    public class CatalogViewModel : ProductFilter
    {
        public int? BrandId { get; set; }

        public int? SectionId { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
