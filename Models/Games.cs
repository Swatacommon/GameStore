using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Games
    {
        public Games()
        {
            GameCategorys = new HashSet<GameCategorys>();
            GameGenres = new HashSet<GameGenres>();
            GameImages = new HashSet<GameImages>();
            GameMethodActivations = new HashSet<GameMethodActivations>();
            GamePlatforms = new HashSet<GamePlatforms>();
            OrderGames = new HashSet<OrderGames>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Count { get; set; }
        public double Rating { get; set; }
        public long PublisherId { get; set; }

        public virtual Publishers Publisher { get; set; }
        public virtual ICollection<GameCategorys> GameCategorys { get; set; }
        public virtual ICollection<GameGenres> GameGenres { get; set; }
        public virtual ICollection<GameImages> GameImages { get; set; }
        public virtual ICollection<GameMethodActivations> GameMethodActivations { get; set; }
        public virtual ICollection<GamePlatforms> GamePlatforms { get; set; }
        public virtual ICollection<OrderGames> OrderGames { get; set; }
    }
}
