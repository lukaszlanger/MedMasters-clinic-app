using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class DoctorsReferals
    {
        public int IdReferal { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpirationDay { get; set; }
        public int VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
