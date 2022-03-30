using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esto
{
    class Departement
    {
        public string Codedepart { set; get; }
        public string Nomdepart { set; get; }
        public Departement()
        {

        }
        public Departement(string codedepart, string nomdepart)
        {
            this.Codedepart = codedepart;
            this.Nomdepart = nomdepart;
        }
    }
}
