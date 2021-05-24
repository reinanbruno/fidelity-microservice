using System;
using System.Collections.Generic;

#nullable disable

namespace ProductService.Core.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Products = new HashSet<Product>();
        }

        public int SubcategoryId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public byte Active { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
