using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInLogOut
{
    [Serializable]
    public class Account
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }
}
