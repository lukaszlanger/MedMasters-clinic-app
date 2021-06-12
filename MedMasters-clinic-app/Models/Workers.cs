using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class Workers
    {
        public Workers()
        {
            DoctorSpecializations = new HashSet<DoctorSpecializations>();
            Visits = new HashSet<Visits>();
            WorkingDays = new HashSet<WorkingDays>();
        }

        public int IdWorker { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<DoctorSpecializations> DoctorSpecializations { get; set; }
        public virtual ICollection<Visits> Visits { get; set; }
        public virtual ICollection<WorkingDays> WorkingDays { get; set; }
    }
}
