using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.DTO
{
    public class ProductDTO : INameEntity, IOrderEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public BrandDTO Brand { get; set; }

        public bool? StatusHome { get; set; }

        public bool? StatusNew { get; set; }

        public bool? StatusSale { get; set; }
    }
}
