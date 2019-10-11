using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.ViewModel
{
    public class PageViewModel
    {
        /// <summary>
        /// Общее колличество эдементов
        /// </summary>
        public int TotalItes { get; set; }

        /// <summary>
        /// Объем страници
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Номер страници
        /// </summary>
        public int PageNumer { get; set; }

        /// <summary>
        /// Общеее колличество страниц
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItes / PageSize);
    }
}
