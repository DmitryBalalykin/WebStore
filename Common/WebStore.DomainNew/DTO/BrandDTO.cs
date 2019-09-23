using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.DTO
{
    public class BrandDTO : INameEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
