using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.Traitements
{
    class Chirurgie : Traitement
    {
        private string chirurgien;
        private string anesthesiste;
        private string resultat_examen;
        private string Image;

        public string Chirurgien { get => chirurgien; set => chirurgien = value; }
        public string Anesthesiste { get => anesthesiste; set => anesthesiste = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
        public string Image1 { get => Image; set => Image = value; }
    }
}
