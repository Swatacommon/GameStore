using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Publishers
    {
        public Publishers()
        {
            Games = new HashSet<Games>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
