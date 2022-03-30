using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esto
{
    class Etudiant
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Departement { get; set; }
        public String Filliere { get; set; }

        public Etudiant(string nom, string prenom, string departement, string filliere)
        {
            Nom = nom;
            Prenom = prenom;
            Departement = departement;
            Filliere = filliere;
        }
    }
}
