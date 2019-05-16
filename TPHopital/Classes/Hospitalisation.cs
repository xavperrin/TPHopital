using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
    public class Hospitalisation
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
    }
}
