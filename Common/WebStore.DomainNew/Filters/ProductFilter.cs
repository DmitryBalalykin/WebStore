using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.Filters
{
    public class ProductFilter
    {
        public int? SectionId { get; set; }

        public int? BrandId { get; set; }

        public bool? StatusHome { get; set; }

        public bool? StatusNew { get; set; }

        public bool? StatusSale { get; set; }

        public List<int> Ids { get; set; }
    }
}
