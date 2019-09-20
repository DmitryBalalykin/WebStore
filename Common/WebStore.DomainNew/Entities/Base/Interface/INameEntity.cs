using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.Entities.Base.Interface
{
    public interface INameEntity:IBaseEntity
    {
        string Name { get; set; }
    }
}
