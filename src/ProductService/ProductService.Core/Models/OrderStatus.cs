using ProductService.Core.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProductService.Core.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderHistories = new HashSet<OrderHistory>();
            Orders = new HashSet<Order>();
        }

        public char OrderStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
