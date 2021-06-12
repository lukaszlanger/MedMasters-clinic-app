using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class WorkingDays
    {
        public int IdWorkingDay { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int WorkerId { get; set; }

        public virtual Workers Worker { get; set; }
    }
}
