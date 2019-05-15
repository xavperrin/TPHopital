using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
    public class Consultation
    {
        private int id_consultation;
        private DateTime date_consultation;
        private string synthese;
        private int type_consultation_id;

        public int Id_consultation { get => id_consultation; set => id_consultation = value; }
        public DateTime Date_consultation { get => date_consultation; set => date_consultation = value; }
        public string Synthese { get => synthese; set => synthese = value; }
        public int Fk_id_type_consultation { get => type_consultation_id; set => type_consultation_id = value; }
    }
}
