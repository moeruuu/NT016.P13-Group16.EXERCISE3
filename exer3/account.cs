using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exer3
{
    internal class account
    {
        private string id { get; }
        private string username { get; }
        private string password { get; }
        private string email { get; }
        private string fullname { get; }
        private string birthday { get; }
        public account(string id, string username, string password, string email, string fullname, string birthday)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.fullname = fullname;
            this.birthday = birthday;
        }
    }
}
