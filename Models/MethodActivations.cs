using System;
using System.Collections.Generic;

namespace Models
{
    public partial class MethodActivations
    {
        public MethodActivations()
        {
            GameMethodActivations = new HashSet<GameMethodActivations>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameMethodActivations> GameMethodActivations { get; set; }
    }
}
