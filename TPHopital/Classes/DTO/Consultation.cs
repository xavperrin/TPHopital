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
        private int rdv_code;
        private int prescription_id;
        private int medecin_id;

        public int Id_consultation { get => id_consultation; set => id_consultation = value; }
        public DateTime Date_consultation { get => date_consultation; set => date_consultation = value; }
        public string Synthese { get => synthese; set => synthese = value; }
        public int Type_consultation_id { get => type_consultation_id; set => type_consultation_id = value; }
        public int Rdv_code { get => rdv_code; set => rdv_code = value; }
        public int Prescription_id { get => prescription_id; set => prescription_id = value; }
        public int Medecin_id { get => medecin_id; set => medecin_id = value; }
    }
}
