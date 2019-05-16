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

        public string Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
        public string Image { get => image; set => image = value; }
    }
}
