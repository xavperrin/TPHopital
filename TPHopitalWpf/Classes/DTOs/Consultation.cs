using System;
using System.Collections.Generic;
using System.Text;


namespace TPHopitalWpf.Classes.DTOs
{
    public class Consultation:DTO
    {
        private int id_consultation;
        private DateTime date_consultation;
        private string synthese;
        private int type_consultation_id;
        private int rdv_code;
        private int prescription_id;
        private int medecin_id;

        public Consultation()
        {
        }

        public Consultation(int id_consultation, DateTime date_consultation, string synthese, int type_consultation_id, int rdv_code, int prescription_id, int medecin_id)
        {
            this.id_consultation = id_consultation;
            this.date_consultation = date_consultation;
            this.synthese = synthese;
            this.type_consultation_id = type_consultation_id;
            this.rdv_code = rdv_code;
            this.prescription_id = prescription_id;
            this.medecin_id = medecin_id;
        }

        public int Id_consultation { get => id_consultation; set => id_consultation = value; }
        public DateTime Date_consultation { get => date_consultation; set => date_consultation = value; }
        public string Synthese { get => synthese; set => synthese = value; }
        public int Type_consultation_id { get => type_consultation_id; set => type_consultation_id = value; }
        public int Rdv_code { get => rdv_code; set => rdv_code = value; }
        public int Prescription_id { get => prescription_id; set => prescription_id = value; }
        public int Medecin_id { get => medecin_id; set => medecin_id = value; }

        public override bool CheckData()
        {
            if (this.Date_consultation == null)
                return false;
            if (synthese == "")
                return false;
            if (synthese == null)
                return false;
            else return true;
        }

        public override string ToString()
        {
            return "Consultation (id:" + id_consultation + "date:" + date_consultation + "Synthèse:" + type_consultation_id + "rdv code:" + rdv_code + "id prescription:" + prescription_id + "id medecin:" + medecin_id + ")";
        }
    }
}
