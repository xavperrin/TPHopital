using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TPHopitalWpfEF.Classes.DTOs;

namespace TPHopitalWpfEF.Classes
{
    public class Medecin : DTO
    {
        private int id_medecin;
        private string nom_medecin;
        private string prenom_medecin;
        private string tel_medecin;

        public Medecin()
        {
        }

        public Medecin(string nom_medecin, string prenom_medecin, string tel_medecin)
        {           
            Nom_medecin = nom_medecin;
            Prenom_medecin = prenom_medecin;
            Tel_medecin = tel_medecin;
        }

        public int Id_medecin { get => id_medecin; set => id_medecin = value; }
        public string Nom_medecin { get => nom_medecin; set => nom_medecin = value; }
        public string Prenom_medecin { get => prenom_medecin; set => prenom_medecin = value; }
        public string Tel_medecin { get => tel_medecin; set => tel_medecin = value; }

        public override bool CheckData()
        {
            if (Nom_medecin == null)
                return false;
            if (Nom_medecin == "")
                return false;
            if (Prenom_medecin == null)
                return false;
            if (Prenom_medecin == "")
                return false;
            else return true;
        }

        public override string ToString()
        {
            return "Medecin (id :"+Id_medecin+"nom:"+ Nom_medecin+" prenom:"+ Prenom_medecin+" telephone:"+Tel_medecin+")";
        }

        internal static ObservableCollection<Medecin> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
