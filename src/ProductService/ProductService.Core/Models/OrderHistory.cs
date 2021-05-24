using ProductService.Core.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProductService.Core.Models
{
    public partial class OrderHistory
    {
        public int OrderHistoryId { get; set; }
        public int OrderId { get; set; }
        public char OrderStatusId { get; set; }
        public string Details { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
