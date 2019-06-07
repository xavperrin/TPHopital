using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopitalWpf.Classes.Traitements
{
    class Chirurgie : Traitement
    {
        private string chirurgien;
        private string anesthesiste;

        public Chirurgie()
        {

        }

        public Chirurgie(DateTime date_chirurgie, decimal prix_chirurgie,  string chirurgien, string anesthesiste)
        {
            Date_traitement=date_chirurgie;
            Prix_traitement =prix_chirurgie;
            Chirurgien = chirurgien;
            Anesthesiste = anesthesiste;
        }

        public string Chirurgien { get => chirurgien; set => chirurgien = value; }
        public string Anesthesiste { get => anesthesiste; set => anesthesiste = value; }


        public override bool CheckData()
        {
            if ((chirurgien == null) || (chirurgien==""))
                return false;
            if (Date_traitement == null)
                return false;
            if (Prix_traitement < 0)
                return false;

            else return true;
        }
        public override string ToString()
        {
            return  "\nChirurgie (chirurgien: " + chirurgien + ", anesthesiste: " + anesthesiste + ")";
        }
    }
}
