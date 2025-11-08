using System;

namespace api.Models
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string SeriaPasport { get; set; }
        public string NumberPasport { get; set; }
        public string EmployeePhone { get; set; }
        public DateTime DateBirthEmployee { get; set; }
        public string EmployeeEmail { get; set; }
        public int? PostId { get; set; }
        public int? DepartamentId { get; set; }
        public int? UserId { get; set; }
    }
}
