using System;

namespace api.Models
{
    public partial class Client
    {

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string SeriaPass { get; set; }
        public string NumberPass { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirthClient { get; set; }
        public string Email { get; set; }

    }
}
