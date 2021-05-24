using System;
using System.Collections.Generic;

#nullable disable

namespace ProductService.Core.Models
{
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public byte Active { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
