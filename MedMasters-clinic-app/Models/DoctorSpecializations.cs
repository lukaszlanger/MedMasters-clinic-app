using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class DoctorSpecializations
    {
        public int IdDoctorSpecialization { get; set; }
        public int DoctorId { get; set; }
        public int SpecializationId { get; set; }

        public virtual Workers Doctor { get; set; }
        public virtual MedicalSpecializations Specialization { get; set; }
    }
}
