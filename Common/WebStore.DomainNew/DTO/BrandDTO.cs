using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.DTO
{
    public class BrandDTO : NameEntity, IOrderEntity
    {
        public int Order { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
