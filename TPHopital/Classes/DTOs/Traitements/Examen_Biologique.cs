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

        public Examen_Biologique(DateTime date_examen, decimal prix_examen, string designation, string resultat_examen)
        {
            Date_traitement = date_examen;
            Prix_traitement = prix_examen;
            Designation = designation;
            Resultat_examen = resultat_examen;
        }

        public string Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }

        public override bool CheckData()
        {
            if ((Designation == null) || (Designation == ""))
                return false;
            if (Date_traitement == null)
                return false;
            if (Prix_traitement < 0)
                return false;

            else return true;
        }

        public override string ToString()
        {
            return base.ToString() + "\nExamen Biologique (designation:" + designation + "resultat examen:" + resultat_examen + ")";
        }
    }
}
