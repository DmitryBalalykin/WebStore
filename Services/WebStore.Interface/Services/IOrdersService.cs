using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.DTO.Order;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.ViewModel;

namespace WebStore.Interface.Services
{
    public interface IOrdersService
    {
        IEnumerable<OrderDTO> GetUserOrders(string userName);

        /// <summary>
        /// Получить заказ по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrderDTO GetOrderById(int id);

        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <param name="orderModel"></param>
        /// <param name="transfromCart"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        OrderDTO CreateOrder(CreateOrderModel orderModel, string userName);
    }
}
