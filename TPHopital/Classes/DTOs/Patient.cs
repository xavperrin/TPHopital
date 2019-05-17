using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
    public class Patient

    {
        private int id_Patient;
        private string nomPatient;
        private string prenomPatient;
        private DateTime dateNaissance;
        private string sexe;
        private string adresse;
        private string situationFamiliale;
        private string assuranceMedicale;
        private string codeassurance;
        private int tel;
        private string nomPere;
        private string nomMere;
        private string nom_P_a_prevenir;
        private int tel_P_a_prevenir;

        

        public int Id_Patient { get => id_Patient; set => id_Patient = value; }
        public string NomPatient { get => nomPatient; set => nomPatient = value; }
        public string PrenomPatient { get => prenomPatient; set => prenomPatient = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string SituationFamiliale { get => situationFamiliale; set => situationFamiliale = value; }
        public string AssuranceMedicale { get => assuranceMedicale; set => assuranceMedicale = value; }
        public string Codeassurance { get => codeassurance; set => codeassurance = value; }
        public int Tel { get => tel; set => tel = value; }
        public string NomPere { get => nomPere; set => nomPere = value; }
        public string NomMere { get => nomMere; set => nomMere = value; }
        public string Nom_P_a_prevenir { get => nom_P_a_prevenir; set => nom_P_a_prevenir = value; }
        public int Tel_P_a_prevenir { get => tel_P_a_prevenir; set => tel_P_a_prevenir = value; }
    }

}
