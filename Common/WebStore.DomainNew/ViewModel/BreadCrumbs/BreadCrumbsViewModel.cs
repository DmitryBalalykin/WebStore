using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.ViewModel.BreadCrumbs
{
    public class BreadCrumbsViewModel
    {
        /// <summary>
        /// Индефикатор ХК
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя ХК
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип ХК
        /// </summary>
        public BreadCrumbsType BreadCrumbsType { get; set; }
    }
}
