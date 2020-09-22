using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderGames = new HashSet<OrderGames>();
        }

        public long Id { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderGames> OrderGames { get; set; }
    }
}
