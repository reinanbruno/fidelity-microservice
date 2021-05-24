using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.Core.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        public decimal PointsValue { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte Active { get; set; }

        public virtual Subcategory Subcategory { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
