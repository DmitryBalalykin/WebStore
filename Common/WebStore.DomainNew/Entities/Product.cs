using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.Entities
{
    [Table(name:"Products")]
    public class Product : NameEntity, IOrderEntity
    {
        public int Order { get; set; }

        public int SectionId { get; set; }

        public int? BrandId { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public bool? StatusHome { get; set; }

        public bool? StatusNew { get; set; }

        public bool? StatusSale { get; set; }

        [ForeignKey(name: "SectionId")]
        public virtual Section Section { get; set; }

        [ForeignKey(name:"BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
