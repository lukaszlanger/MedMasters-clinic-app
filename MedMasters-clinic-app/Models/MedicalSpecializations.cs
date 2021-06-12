using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class MedicalSpecializations
    {
        public MedicalSpecializations()
        {
            DoctorSpecializations = new HashSet<DoctorSpecializations>();
        }

        public int IdSpecialization { get; set; }
        public string SpecializationName { get; set; }

        public virtual ICollection<DoctorSpecializations> DoctorSpecializations { get; set; }
    }
}
