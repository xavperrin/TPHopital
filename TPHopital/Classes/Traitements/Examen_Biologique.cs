using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.Traitements
{
    public class Examen_Biologique : Traitement
    {
        
        private int designation;
        private string resultat_examen;

        public int Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
    }
}
