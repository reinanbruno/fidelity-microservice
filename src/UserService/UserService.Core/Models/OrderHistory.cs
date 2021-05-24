using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.Core.Models
{
    public partial class OrderHistory
    {
        public int OrderHistoryId { get; set; }
        public int OrderId { get; set; }
        public string OrderStatusId { get; set; }
        public string Details { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
