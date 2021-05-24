using System;
using System.Collections.Generic;

#nullable disable

namespace ProductService.Core.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserAddresses = new HashSet<UserAddress>();
            UserPointCompanies = new HashSet<UserPointCompany>();
            UserPointHistories = new HashSet<UserPointHistory>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string IndividualTaxpayerRegistration { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
        public decimal CurrentPointsBalance { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte Active { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<UserPointCompany> UserPointCompanies { get; set; }
        public virtual ICollection<UserPointHistory> UserPointHistories { get; set; }
    }
}
