using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.DTO.Order;
using WebStore.Interface.Services;

namespace WebStore.Clients.Orders
{
    public class OrdersClient : BaseClient,IOrdersService
    {
        public OrdersClient(IConfiguration configuration) : base(configuration, "api/orders")
        {
        }

        public OrderDTO CreateOrder(CreateOrderModel orderModel, string userName)
        {
            var response = Post($"{_ServiceAddress}/{userName}", orderModel);
            return response.Content.ReadAsAsync<OrderDTO>().Result;
        }

        public OrderDTO GetOrderById(int id)
        {
            return Get<OrderDTO>($"{_ServiceAddress}/{id}");
        }

        public IEnumerable<OrderDTO> GetUserOrders(string userName)
        {
            return Get<List<OrderDTO>>($"{_ServiceAddress}/user/{userName}");
        }
    }
}
