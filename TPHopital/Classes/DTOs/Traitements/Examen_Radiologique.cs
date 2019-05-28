using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.Traitements
{
    public class Examen_Radiologique : Traitement 
    {
        private string designation;
        private string resultat_examen;
        private string image;

        public Examen_Radiologique()
        {

        }

        public Examen_Radiologique(DateTime date_examen, decimal prix_examen, string designation, string resultat_examen, string image)
        {
            Date_traitement = date_examen;
            Prix_traitement = prix_examen;
            Designation = designation;
            Resultat_examen = resultat_examen;
            Image = image;
        }

        public string Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
        public string Image { get => image; set => image = value; }

        public override bool CheckData()
        {
            if ((Image == null) || (Image == ""))
                return false;
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
            return "\nExamen Radiologique (designation:" + designation + "resultat examen:" + resultat_examen + "image:" + image + ")";
        }
    }
}
