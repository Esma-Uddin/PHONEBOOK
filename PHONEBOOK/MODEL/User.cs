using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHONEBOOK.MODEL
{
    internal class User
    {   public int id { get; set; }
        public string name { get; set; } 
        public string password { get; set; }

        public User(string name,string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
