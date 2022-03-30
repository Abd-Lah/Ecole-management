using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esto
{
    class Utilisateurs
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Acces { set; get; }
        public Utilisateurs()
        {

        }
        public Utilisateurs(string username, string password,string acces)
        {
            Username = username;
            Password = password;
            Acces = acces;
        }
    }
}
