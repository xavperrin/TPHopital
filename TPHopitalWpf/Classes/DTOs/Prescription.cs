using System;
using System.Collections.Generic;
using System.Text;
using TPHopitalWpfEF.Classes.DTOs;

namespace TPHopitalWpfEF.Classes
{
    public class Prescription:DTO
    {
        private  int id_prescription;
        private DateTime date_prescription;
        private string nom_patient;
        private string prenom_patient;
        private string note;

        public int Id_prescription { get => id_prescription; set => id_prescription = value; }
        public DateTime Date_prescription { get => date_prescription; set => date_prescription = value; }
        public string Nom_patient { get => nom_patient; set => nom_patient = value; }
        public string Prenom_patient { get => prenom_patient; set => prenom_patient = value; }
        public string Note { get => note; set => note = value; }

        public override bool CheckData()
        {
            if (Date_prescription == null)
                return false;
            if (Nom_patient == "")
                return false;
            if (Nom_patient == null)
                return false;
            if (prenom_patient == "")
                return false;
            if (prenom_patient == null)
                return false;
            else return true;
        }
    }
}
