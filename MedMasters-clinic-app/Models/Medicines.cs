using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class Medicines
    {
        public int IdMedicine { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpirationDay { get; set; }
        public int VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
