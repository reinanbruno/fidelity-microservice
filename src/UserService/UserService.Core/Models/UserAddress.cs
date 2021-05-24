using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.Core.Models
{
    public partial class UserAddress
    {
        public UserAddress()
        {
            Orders = new HashSet<Order>();
        }

        public int UserAddressId { get; set; }
        public int UserId { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string InformationAdditional { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte Active { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
