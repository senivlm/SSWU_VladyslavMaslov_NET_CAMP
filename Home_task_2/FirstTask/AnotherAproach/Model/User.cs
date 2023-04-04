using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Model
{
    public class User
    {
        public string userName { get; private set; }
        public string password { get; private set; }
        public int waterUsed;

        public User(string userName, string password) 
        {
            this.userName = userName;
            this.password = password;
            waterUsed = 0;
        }
    }
}
