using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.ViewModel
{
    public class SectionViewModel : INameEntity, IOrderEntity
    {
        public SectionViewModel()
        {
            ChildSections = new List<SectionViewModel>();
        }

        public int Id { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Дочерние секции
        /// </summary>
        public List<SectionViewModel> ChildSections { get; set; }

        /// <summary>
        /// Родительские секции
        /// </summary>
        public SectionViewModel ParentSection { get; set; }
    }
}
