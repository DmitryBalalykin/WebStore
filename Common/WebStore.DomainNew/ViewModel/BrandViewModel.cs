using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.ViewModel
{
    public class BrandViewModel : INameEntity, IOrderEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public int ProductCount { get; set; }
    }
}
