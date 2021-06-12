using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class Visits
    {
        public Visits()
        {
            DoctorsReferals = new HashSet<DoctorsReferals>();
            Medicines = new HashSet<Medicines>();
        }

        public int IdVisit { get; set; }
        public string VisitsDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Compleated { get; set; }
        public string PatientId { get; set; }
        public int DoctorId { get; set; }

        public virtual Workers Doctor { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual ICollection<DoctorsReferals> DoctorsReferals { get; set; }
        public virtual ICollection<Medicines> Medicines { get; set; }
    }
}
