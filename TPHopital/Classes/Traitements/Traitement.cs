using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
   public abstract  class Traitement
    {
        private int id;
        private DateTime date_traitement;
        private decimal prix_traitement;
        private int id_facture;


        protected int Id { get => id; set => id = value; }
        protected DateTime Date_traitement { get => date_traitement; set => date_traitement = value; }
        protected decimal Prix_traitement { get => prix_traitement; set => prix_traitement = value; }
        protected int Id_facture { get => id_facture; set => id_facture = value; }
    }
}
