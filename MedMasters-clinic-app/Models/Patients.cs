using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Visits = new HashSet<Visits>();
        }

        public string Pesel { get; set; }
        public string Surname { get; set; }
        public string MaidenName { get; set; }
        public string Forename { get; set; }
        public string SecondForename { get; set; }
        public bool Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string CityOfBirth { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Visits> Visits { get; set; }
    }
}
