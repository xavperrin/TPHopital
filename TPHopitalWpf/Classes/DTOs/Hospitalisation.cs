using System;
using System.Collections.Generic;
using System.Text;
using TPHopitalWpfEF.Classes.DTOs;

namespace TPHopitalWpfEF.Classes
{
    public class Hospitalisation:DTO
    {
        private int id_admission;
        private DateTime date_admission;
        private string type_admission;
        private string motif_admission;
        private string medecin_traitant;
        private string nom_accompagnant;
        private string prenom_accompagnant;
        private string lien_parente;
        private DateTime date_entreeAcc;
        private DateTime date_sortieAcc;
        private DateTime date_sortie;
        private string motif_sortie;
        private string resultat_sortie;
        private DateTime date_deces;
        private string motif_deces;
        private int patient_id;
        private int traitement_id;

        public Hospitalisation()
        {

        }

        public Hospitalisation(int id_admission, DateTime date_admission, string type_admission, string motif_admission, string medecin_traitant, string nom_accompagnant, string prenom_accompagnant, string lien_parente, DateTime date_entreeAcc, DateTime date_sortieAcc, DateTime date_sortie, string motif_sortie, string resultat_sortie, DateTime date_deces, string motif_deces, int patient_id, int traitement_id)
        {
            this.id_admission = id_admission;
            this.date_admission = date_admission;
            this.type_admission = type_admission;
            this.motif_admission = motif_admission;
            this.medecin_traitant = medecin_traitant;
            this.nom_accompagnant = nom_accompagnant;
            this.prenom_accompagnant = prenom_accompagnant;
            this.lien_parente = lien_parente;
            this.date_entreeAcc = date_entreeAcc;
            this.date_sortieAcc = date_sortieAcc;
            this.date_sortie = date_sortie;
            this.motif_sortie = motif_sortie;
            this.resultat_sortie = resultat_sortie;
            this.date_deces = date_deces;
            this.motif_deces = motif_deces;
            this.patient_id = patient_id;
            this.traitement_id = traitement_id;
        }

        public int Id_admission { get => id_admission; set => id_admission = value; }
        public DateTime Date_admission { get => date_admission; set => date_admission = value; }
        public string Type_admission { get => type_admission; set => type_admission = value; }
        public string Motif_admission { get => motif_admission; set => motif_admission = value; }
        public string Medecin_traitant { get => medecin_traitant; set => medecin_traitant = value; }
        public string Nom_accompagnant { get => nom_accompagnant; set => nom_accompagnant = value; }
        public string Prenom_accompagnant { get => prenom_accompagnant; set => prenom_accompagnant = value; }
        public string Lien_parente { get => lien_parente; set => lien_parente = value; }
        public DateTime Date_entreeAcc { get => date_entreeAcc; set => date_entreeAcc = value; }
        public DateTime Date_sortieAcc { get => date_sortieAcc; set => date_sortieAcc = value; }
        public DateTime Date_sortie { get => date_sortie; set => date_sortie = value; }
        public string Motif_sortie { get => motif_sortie; set => motif_sortie = value; }
        public string Resultat_sortie { get => resultat_sortie; set => resultat_sortie = value; }
        public DateTime Date_deces { get => date_deces; set => date_deces = value; }
        public string Motif_deces { get => motif_deces; set => motif_deces = value; }
        public int Patient_id { get => patient_id; set => patient_id = value; }
        public int Traitement_id { get => traitement_id; set => traitement_id = value; }

        

        public override bool CheckData()
        {
            if (date_admission == null)
                return false;
            if (type_admission == "")
                return false;
            if (type_admission == null)
                return false;
            if (motif_admission == "")
                return false;
            else return true;
        }

        public override string ToString()
        {
            return "Hospitalisation (id:" + id_admission + ", date admission:" + date_admission + ", type:" + type_admission + ", motif:" + motif_admission +
                "\nmedecin:" + medecin_traitant + ",nom accompagnant:" + nom_accompagnant + ", prenom accompagnant:" + prenom_accompagnant + ",lien parenté:" + lien_parente +
                "\ndate entree acc:" + date_entreeAcc + ", date sortie acc:" + date_sortieAcc + ", date sortie:" + date_sortie + "motif sortie:" + motif_sortie +
                "\ndate deces:" + date_deces + ",motif deces:" + motif_deces + ",id patient:" + patient_id + ",id traitement:" + traitement_id + ")";
        }
    }
}
