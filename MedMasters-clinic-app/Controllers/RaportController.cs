using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klinika.Models;
using Klinika.ModelView;
namespace Klinika.Controllers
{
    public class RaportController : Controller
    {
        public IActionResult Index(string id)
        {
            masterContext db = new masterContext();
            List<Patients> pac = db.Patients.ToList();
            List<Visits> vis = db.Visits.ToList();
            List<Medicines> med = db.Medicines.ToList();

            var r = from p in pac
                    join v in vis on p.Pesel equals v.PatientId into tab1 
                    from v in tab1.DefaultIfEmpty() where p.Pesel.Equals(id)
                    join m in med on v.IdVisit equals m.VisitId into tab2
                    from m in tab2.DefaultIfEmpty() where v.IdVisit.Equals(m.VisitId)
                    select new Raport { Patients = p, Visits = v, Medicines= m };

            return View(r);
        }
    }
}