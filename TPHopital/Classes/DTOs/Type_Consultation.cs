using System;
using System.Collections.Generic;
using System.Text;
using TPHopital.Classes.DTOs;

namespace TPHopital.Classes
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

        public override string ToString()
        {
            return "Type consultation (id:" + id_type_consultation + ", type:" + type_consultation + ", prix:" + prix_consultation + "€";
        }
    }
}
