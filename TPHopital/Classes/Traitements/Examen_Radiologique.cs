using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.Traitements
{
    class Examen_Radiologique : Traitement 
    {
        private int designation;
        private string resultat_examen;
        private string image;

        public int Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
        public string Image { get => image; set => image = value; }
    }
}
