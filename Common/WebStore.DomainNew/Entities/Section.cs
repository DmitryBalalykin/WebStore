using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.Entities
{
    [Table(name: "Sections")]
    public class Section : NameEntity, IOrderEntity
    {
        /// <summary>
        /// Родительская категория если существует
        /// </summary>
        public int? ParentId { get; set; }

        public int Order { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }

        [ForeignKey(name:"ParentId")]
        public virtual Section ParentSection { get; set; }
    }
}
