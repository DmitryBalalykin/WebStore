using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
