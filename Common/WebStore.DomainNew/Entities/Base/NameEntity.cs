using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.DomainNew.Entities.Base
{
    public class NameEntity : INameEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
