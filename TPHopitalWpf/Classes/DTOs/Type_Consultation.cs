using System;
using System.Collections.Generic;
using System.Text;
using TPHopitalWpfEF.Classes.DTOs;

namespace TPHopitalWpfEF.Classes
{
    public class Type_Consultation : DTO
    {
        private int id_type_consultation;
        private string type_consultation;
        private decimal prix_consultation;

        public Type_Consultation()
        {

        }

        public Type_Consultation(int id_type_consultation, string type_consultation, decimal prix_consultation)
        {
            this.Id_type_consultation = id_type_consultation;
            this.Type_consultation = type_consultation;
            this.Prix_consultation = prix_consultation;
        }

        public int Id_type_consultation { get => id_type_consultation; set => id_type_consultation = value; }
        public string Type_consultation { get => type_consultation; set => type_consultation = value; }
        public decimal Prix_consultation { get => prix_consultation; set => prix_consultation = value; }


        public override bool CheckData()
        {

            if (type_consultation == "")
                return false;
            if (type_consultation == null)
                return false;
            if (prix_consultation < 0)
                return false;
            
            else return true;
        }
        public override string ToString()
        {
            return "Type consultation (id:" + id_type_consultation + ", type:" + type_consultation + ", prix:" + prix_consultation + "€";
        }
    }
}
