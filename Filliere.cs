using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esto
{
    public class Filliere
    {
        public string Codedepart { set; get; }
        public string Codefill { set; get; }
        public string Nomfill { set; get; }
        public Filliere()
        {

        }
        public Filliere(string codefill, string codedepart, string nomfill)
        {
            this.Codedepart = codedepart;
            this.Codefill = codefill;
            this.Nomfill = nomfill;
        }
    }
}
