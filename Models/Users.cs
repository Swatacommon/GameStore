using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
