using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Genres
    {
        public Genres()
        {
            GameGenres = new HashSet<GameGenres>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameGenres> GameGenres { get; set; }
    }
}
