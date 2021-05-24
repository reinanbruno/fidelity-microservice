using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.Core.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int UserAddressId { get; set; }
        public string OrderStatusId { get; set; }
        public decimal PointsValue { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual UserAddress UserAddress { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
