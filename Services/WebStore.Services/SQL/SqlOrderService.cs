using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.DAL;
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
        public Order CreateOrder(OrderViewModel orderModel,
                                 CartViewModel transfromCart,
                                 string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;

            using (var transaction = _context.Database.BeginTransaction())
            {
                var order = new Order
                {
                    Address = orderModel.Address,
                    Name = orderModel.Name,
                    Date = DateTime.Now,
                    Phone = orderModel.Phone,
                    User = user
                };

                _context.Orders.Add(order);

                foreach (var item in transfromCart.Items)
                {
                    var productVm = item.Key;
                    var product = _context.Products.FirstOrDefault(x => x.Id == productVm.Id);

                    if (product == null)
                        throw new InvalidCastException("Продукты не найденны в базе");


                    var orderItem = new OrderItem
                    {
                        Price = product.Price,
                        Quantity = item.Value,

                        Order = order,
                        Product = product
                    };
                    _context.OrderItems.Add(orderItem);
                }

                _context.SaveChanges();
                transaction.Commit();

                return order;
            }
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include("OrderItem")
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            return _context.Orders
                .Include("User") //Подключаем связанные сущьности
                .Include("OrderItem") //Подключаем связанные сущьности
                .Where(o => o.User.UserName == userName) //отфильтруем
                .ToList();
        }
    }
}
