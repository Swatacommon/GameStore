using System;
using System.Collections.Generic;

namespace Models
{
    public partial class OrderGames
    {
        public long OrderId { get; set; }
        public long GameId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Orders Order { get; set; }
    }
}
