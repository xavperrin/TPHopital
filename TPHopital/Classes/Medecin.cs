using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
    public class Medecin
    {

        private int id_medecin;
        private string nom_medecin;
        private string prenom_medecin;
        private int tel;

        public global::System.Int32 Id_medecin { get => id_medecin; set => id_medecin = value; }
        public global::System.String Nom_medecin { get => nom_medecin; set => nom_medecin = value; }
        public global::System.String Prenom_medecin { get => prenom_medecin; set => prenom_medecin = value; }
        public global::System.Int32 Tel { get => tel; set => tel = value; }
    }
}
