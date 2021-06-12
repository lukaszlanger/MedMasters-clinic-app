using System;
using System.Collections.Generic;

namespace Klinika.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Workers = new HashSet<Workers>();
        }

        public int IdRole { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }
    }
}
