using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.Core.Models
{
    public partial class UserPointHistory
    {
        public int UserPointHistoryId { get; set; }
        public int UserId { get; set; }
        public decimal PointBalance { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual User User { get; set; }
    }
}
