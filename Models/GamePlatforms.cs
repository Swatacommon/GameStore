using System;
using System.Collections.Generic;

namespace Models
{
    public partial class GamePlatforms
    {
        public long GameId { get; set; }
        public long PlatformId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Platforms Platform { get; set; }
    }
}
