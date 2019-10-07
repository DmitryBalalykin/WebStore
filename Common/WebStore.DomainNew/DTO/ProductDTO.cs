using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.DTO
{
    public class ProductDTO : NameEntity, IOrderEntity
    {
        public int Order { get; set; }

        public int SectionId { get; set; }

        public int? BrandId { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public bool? StatusHome { get; set; }

        public bool? StatusNew { get; set; }

        public bool? StatusSale { get; set; }

        public BrandDTO Brand { get; set; }

        public SectionDTO Section { get; set; }

        //public virtual Section Section { get; set; }
    }
}
