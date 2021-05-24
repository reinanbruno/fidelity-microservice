using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.Core.Models
{
    public partial class UserPointStatus
    {
        public UserPointStatus()
        {
            UserPointCompanies = new HashSet<UserPointCompany>();
        }

        public string UserPointStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserPointCompany> UserPointCompanies { get; set; }
    }
}
