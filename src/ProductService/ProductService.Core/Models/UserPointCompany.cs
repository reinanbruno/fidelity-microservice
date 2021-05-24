using System;
using System.Collections.Generic;

#nullable disable

namespace ProductService.Core.Models
{
    public partial class UserPointCompany
    {
        public int UserPointCompanyId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string UserPointStatusId { get; set; }
        public decimal PointsValue { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual UserPointStatus UserPointStatus { get; set; }
    }
}
