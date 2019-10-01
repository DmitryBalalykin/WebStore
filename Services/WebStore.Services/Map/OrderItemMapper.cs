using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO.Order;
using WebStore.DomainNew.Entities;

namespace WebStore.Services.Map
{
    public static class OrderItemMapping
    {
        public static OrderItemDTO ToDTO(this OrderItem orderItem) => orderItem is null ? null : new OrderItemDTO
        {
            Id = orderItem.Id,
            Price = orderItem.Price,
            Quantity = orderItem.Quantity
        };

        public static OrderItem FromDTO(this OrderItemDTO orderItemDTO) => orderItemDTO is null ? null : new OrderItem
        {
            Id = orderItemDTO.Id,
            Price = orderItemDTO.Price,
            Quantity = orderItemDTO.Quantity
        };
    }
}
