using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.Traitements
{
    public class Examen_Biologique : Traitement
    {        
        private string designation;
        private string resultat_examen;

        public Examen_Biologique()
        {

        }

        public Examen_Biologique(string designation, string resultat_examen)
        {
            this.designation = designation;
            this.resultat_examen = resultat_examen;
        }

        public string Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }

        public override string ToString()
        {
            return base.ToString() + "\nExamen Biologique (designation:" + designation + "resultat examen:" + resultat_examen + ")";
        }
    }
}
