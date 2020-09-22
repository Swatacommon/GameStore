using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Platforms
    {
        public Platforms()
        {
            GamePlatforms = new HashSet<GamePlatforms>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GamePlatforms> GamePlatforms { get; set; }
    }
}
