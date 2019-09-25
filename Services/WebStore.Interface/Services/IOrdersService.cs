using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.ViewModel;

namespace WebStore.Interface.Services
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetUserOrders(string userName);

        /// <summary>
        /// Получить заказ по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order GetOrderById(int id);

        /// <summary>
        /// Сщздать заказ
        /// </summary>
        /// <param name="orderModel"></param>
        /// <param name="transfromCart"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Order CreateOrder(OrderViewModel orderModel, CartViewModel transfromCart, string userName);
    }
}
