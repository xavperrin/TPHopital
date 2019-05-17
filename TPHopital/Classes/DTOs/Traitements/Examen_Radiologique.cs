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

        public Examen_Radiologique(string designation, string resultat_examen, string image)
        {
            this.designation = designation;
            this.resultat_examen = resultat_examen;
            this.image = image;
        }

        public string Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
        public string Image { get => image; set => image = value; }

        public override string ToString()
        {
            return base.ToString() + "\nExamen Radiologique (designation:" + designation + "resultat examen:" + resultat_examen + "image:" + image + ")";
        }
    }
}
