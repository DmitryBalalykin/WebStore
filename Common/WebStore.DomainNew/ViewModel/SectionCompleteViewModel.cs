using System;
using System.Collections.Generic;
using System.Text;
using WebStore.ViewModel;

namespace WebStore.DomainNew.ViewModel
{
    public class SectionCompleteViewModel
    {
        public IEnumerable<SectionViewModel> _section { get; set; }

        /// <summary>
        /// Текущая выбранная родительская секция
        /// </summary>
        public int? currentParentSection { get; set; }

        /// <summary>
        /// Текущая выбранная дочерняя секция
        /// </summary>
        public int? currentSectionID {get;set;}
    }
}
