using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.DTO.Order;
using WebStore.Interface.Services;

namespace WebStore.Controllers
{
    //[Route("api/[controller]")]
    [Route("api / orders")]
    [ApiController, Produces("application/json")]
    public class OrdersController : ControllerBase,IOrdersService
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost("{UserName}")]
        public OrderDTO CreateOrder([FromBody] CreateOrderModel orderModel, string userName)
        {
            return _ordersService.CreateOrder(orderModel, userName);
        }

        [HttpGet("{id}"),ActionName("Get")]
        public OrderDTO GetOrderById(int id)
        {
            return _ordersService.GetOrderById(id);
        }

        [HttpGet("user/{UserName}")]
        public IEnumerable<OrderDTO> GetUserOrders(string userName)
        {
            return _ordersService.GetUserOrders(userName);
        }
    }
}