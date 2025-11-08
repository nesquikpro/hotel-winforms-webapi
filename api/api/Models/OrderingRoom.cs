using System;

namespace api.Models
{
    public partial class OrderingRoom
    {
        public int IdOrderingRoom { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int? ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int? NumberId { get; set; }

    }
}
