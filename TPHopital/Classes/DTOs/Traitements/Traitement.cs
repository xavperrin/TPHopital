using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
   public abstract  class Traitement
    {
        protected int id_traitement;
        protected DateTime date_traitement;
        protected decimal prix_traitement;
        protected int facture_id;

        public int Id_traitement { get => id_traitement; set => id_traitement = value; }
        public DateTime Date_traitement { get => date_traitement; set => date_traitement = value; }
        public decimal Prix_traitement { get => prix_traitement; set => prix_traitement = value; }
        public int Facture_id { get => facture_id; set => facture_id = value; }

        public override string ToString()
        {
            return "Traitement (id:"+id_traitement+",date du traitement:"+date_traitement+",prix du traitement:"+prix_traitement+"€,id facture:"+facture_id+")";
        }
    }
}
