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
        private string tel;
        private string nomPere;
        private string nomMere;
        private string nom_P_a_prevenir;
        private string tel_P_a_prevenir;

        public Patient()
        {

        }

        public Patient(int id_Patient, string nomPatient, string prenomPatient, DateTime dateNaissance, string sexe, string adresse, string situationFamiliale, string assuranceMedicale, string codeassurance, string tel, string nomPere, string nomMere, string nom_P_a_prevenir, string tel_P_a_prevenir)
        {
            this.id_Patient = id_Patient;
            this.nomPatient = nomPatient;
            this.prenomPatient = prenomPatient;
            this.dateNaissance = dateNaissance;
            this.sexe = sexe;
            this.adresse = adresse;
            this.situationFamiliale = situationFamiliale;
            this.assuranceMedicale = assuranceMedicale;
            this.codeassurance = codeassurance;
            this.tel = tel;
            this.nomPere = nomPere;
            this.nomMere = nomMere;
            this.nom_P_a_prevenir = nom_P_a_prevenir;
            this.tel_P_a_prevenir = tel_P_a_prevenir;
        }

        public int Id_Patient { get => id_Patient; set => id_Patient = value; }
        public string NomPatient { get => nomPatient; set => nomPatient = value; }
        public string PrenomPatient { get => prenomPatient; set => prenomPatient = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string SituationFamiliale { get => situationFamiliale; set => situationFamiliale = value; }
        public string AssuranceMedicale { get => assuranceMedicale; set => assuranceMedicale = value; }
        public string Codeassurance { get => codeassurance; set => codeassurance = value; }
        public string Tel { get => tel; set => tel = value; }
        public string NomPere { get => nomPere; set => nomPere = value; }
        public string NomMere { get => nomMere; set => nomMere = value; }
        public string Nom_P_a_prevenir { get => nom_P_a_prevenir; set => nom_P_a_prevenir = value; }
        public string Tel_P_a_prevenir { get => tel_P_a_prevenir; set => tel_P_a_prevenir = value; }

        public override string ToString()
        {
            return "Medecin (id :" + Id_Patient + "nom:" + NomPatient + " prenom:" + PrenomPatient + "date de naissance:" + DateNaissance +
                "\nsexe:"+sexe+"adresse:"+adresse+"situation familiale:"+situationFamiliale+"assurance:"+assuranceMedicale+
                "\nCode assurance:"+codeassurance+"téléphone:"+tel+"nom du père:"+nomPere+"nom de la mère:"+nomMere+
                "\nNom personne à prévenir:"+nom_P_a_prevenir+"Tel personne à prévenir:"+tel_P_a_prevenir+")";
        }
    }

}
