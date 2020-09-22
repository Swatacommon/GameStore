using System;
using System.Collections.Generic;

namespace Models
{
    public partial class GameGenres
    {
        public long GameId { get; set; }
        public long GenreId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Genres Genre { get; set; }
    }
}
