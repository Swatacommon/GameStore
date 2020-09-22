using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Image
    {
        public Image()
        {
            GameImages = new HashSet<GameImages>();
        }

        public string Name { get; set; }
        public string Format { get; set; }

        public virtual ICollection<GameImages> GameImages { get; set; }
    }
}
