using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.Core.Models
{
    public partial class Company
    {
        public Company()
        {
            UserPointCompanies = new HashSet<UserPointCompany>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string EmployerIdentificationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte Active { get; set; }

        public virtual ICollection<UserPointCompany> UserPointCompanies { get; set; }
    }
}
