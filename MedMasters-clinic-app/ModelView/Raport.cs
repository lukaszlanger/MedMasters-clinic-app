using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klinika.Models;

namespace Klinika.ModelView
{
    public class Raport
    {
        public Patients Patients { get; set; }
        public Visits Visits { get; set; }
        public Medicines Medicines { get; set; }

    }
}
