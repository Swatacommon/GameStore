using System;
using System.Collections.Generic;

namespace Models
{
    public partial class GameMethodActivations
    {
        public long GameId { get; set; }
        public long MethodActivationId { get; set; }

        public virtual Games Game { get; set; }
        public virtual MethodActivations MethodActivation { get; set; }
    }
}
