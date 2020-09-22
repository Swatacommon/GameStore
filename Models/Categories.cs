using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Categories
    {
        public Categories()
        {
            GameCategorys = new HashSet<GameCategorys>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameCategorys> GameCategorys { get; set; }
    }
}
