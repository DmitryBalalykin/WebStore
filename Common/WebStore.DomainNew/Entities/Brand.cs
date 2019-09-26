using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.Entities
{
    [Table(name: "Brands")]
    public class Brand : NameEntity, IOrderEntity
    {
        public int Order { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
