using System;
using System.Collections.Generic;

namespace Models
{
    public partial class GameCategorys
    {
        public long GameId { get; set; }
        public long CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Games Game { get; set; }
    }
}
