using System;
using System.Collections.Generic;

namespace Models
{
    public partial class RefreshTokens
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual Genres User { get; set; }
    }
}
