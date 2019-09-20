using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.Entities.Base.Interface
{
    public interface IOrderEntity:IBaseEntity
    {
        int Order { get; set; }//порядок
    }
}
