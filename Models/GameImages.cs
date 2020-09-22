using System;
using System.Collections.Generic;

namespace Models
{
    public partial class GameImages
    {
        public string ImageName { get; set; }
        public long GameId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Image ImageNameNavigation { get; set; }
    }
}
