using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities;

namespace WebStore.Services.Map
{
    public static class OrderMapper
    {
        public static OrderDTO ToDTO(this Order order) => order is null ? null : new OrderDTO
        {
            Id = order.Id,
            Name = order.Name,
            Address = order.Address,
            Data = order.Date,
            Phone = order.Phone,
            orderItems = order.OrderItems.Select(OrderItemMapping.ToDTO).ToArray()
        };

        public static Order FromDTO(this OrderDTO orderDTO) => orderDTO is null ? null : new Order
        {
            Id = orderDTO.Id,
            Name = orderDTO.Name,
            Address = orderDTO.Address,
            Phone = orderDTO.Phone,
            Date = orderDTO.Data,
            OrderItems = orderDTO.orderItems.Select(OrderItemMapping.FromDTO).ToArray()
        };
    }
}
