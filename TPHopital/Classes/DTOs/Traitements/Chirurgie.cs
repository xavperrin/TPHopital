using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.Traitements
{
    class Chirurgie : Traitement
    {
        private string chirurgien;
        private string anesthesiste;

        public Chirurgie()
        {

        }

        public Chirurgie(string chirurgien, string anesthesiste)
        {
            this.chirurgien = chirurgien;
            this.anesthesiste = anesthesiste;
        }

        public string Chirurgien { get => chirurgien; set => chirurgien = value; }
        public string Anesthesiste { get => anesthesiste; set => anesthesiste = value; }

        public override string ToString()
        {
            return base.ToString() + "\nChirurgie (chirurgien: " + chirurgien + ", anesthesiste: " + anesthesiste + ")";
        }
    }
}
