using System;
using System.Collections.Generic;
using System.Text;
using WebStore.ViewModel;

namespace WebStore.DomainNew.ViewModel
{
    public class BrandCompleteViewModel
    {
        public IEnumerable<BrandViewModel> _brand { get; set; }

        /// <summary>
        /// Параметр текущий выбранный бренд
        /// </summary>
        public int? currentBrandId { get; set; }
    }
}
