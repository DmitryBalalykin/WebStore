using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.ViewModel;

namespace WebStore.DomainNew.DTO.Order
{
    public class CreateOrderModel
    {
        public OrderViewModel orderModel { get; set; }

        public List<OrderItemDTO> orderItems { get; set; }

    }
}
