using System;

namespace api.Models
{
    public partial class Accounting
    {
        public int IdAccounting { get; set; }
        public int Amount { get; set; }
        public DateTime DateIssue { get; set; }
        public int? EmployeeId { get; set; }

    }
}
