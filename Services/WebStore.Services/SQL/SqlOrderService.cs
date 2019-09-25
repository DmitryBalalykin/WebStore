using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.DAL;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.DTO.Order;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.ViewModel;
using WebStore.Interface.Services;

namespace WebStore.Services.SQL
{
    public class SqlOrderService : IOrdersService
    {
        private readonly WebStoreContext _context;
        private readonly UserManager<User> _userManager;

        public SqlOrderService(WebStoreContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public OrderDTO CreateOrder(CreateOrderModel orderModel, string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;

            using (var transaction = _context.Database.BeginTransaction())
            {
                var order = new Order
                {
                    Address = orderModel.orderModel.Address,
                    Name = orderModel.orderModel.Name,
                    Date = DateTime.Now,
                    Phone = orderModel.orderModel.Phone,
                    User = user
                };

                _context.Orders.Add(order);

                foreach (var item in orderModel.orderItems)
                {
                    var product = _context.Products.FirstOrDefault(p => p.Id == item.Id);

                    if (product == null)
                        throw new InvalidCastException("Продукты не найденны в базе");


                    var orderItem = new OrderItem
                    {
                        Price = product.Price,
                        Quantity = item.Quantity,

                        Order = order,
                        Product = product
                    };
                    _context.OrderItems.Add(orderItem);
                }

                _context.SaveChanges();
                transaction.Commit();

                return new OrderDTO
                {
                    Id = order.Id,
                    Name = order.Name,
                    Address = order.Address,
                    Phone = order.Phone,
                    Data = order.Date,
                    orderItems = order.OrderItems
                    .Select(item => new OrderItemDTO
                    {
                        Id = item.Id,
                        Price = item.Price,
                        Quantity = item.Quantity
                    })
                    .ToList()
                };
            }
        }

        public OrderDTO GetOrderById(int id)
        {
            var order = _context.Orders
                .Include("OrderItem")
                .FirstOrDefault(o => o.Id == id);

            return new OrderDTO
            {
                Id = order.Id,
                Name = order.Name,
                Address = order.Address,
                Phone = order.Phone,
                Data = order.Date,
                orderItems = order.OrderItems
                    .Select(item => new OrderItemDTO
                    {
                        Id = item.Id,
                        Price = item.Price,
                        Quantity = item.Quantity
                    })
                    .ToList()
            };
        }

        public IEnumerable<OrderDTO> GetUserOrders(string userName)
        {
            return _context.Orders
                .Include("User") //Подключаем связанные сущьности
                .Include("OrderItem") //Подключаем связанные сущьности
                .Where(o => o.User.UserName == userName) //отфильтруем
                .Select(order => new OrderDTO
                {
                    Id = order.Id,
                    Name = order.Name,
                    Address = order.Address,
                    Phone = order.Phone,
                    Data = order.Date,
                    orderItems = order.OrderItems
                    .Select(item => new OrderItemDTO
                    {
                        Id = item.Id,
                        Price = item.Price,
                        Quantity = item.Quantity
                    })
                    .ToList()
                })
                .ToList();
        }
    }
}
