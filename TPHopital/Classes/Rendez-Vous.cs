using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
    public class Rendez_Vous
    {
        private int codeRDV;
        private string medecin;
        private int  id_patient;
        private DateTime Date;

        public int CodeRDV { get => codeRDV; set => codeRDV = value; }
        public string Medecin { get => medecin; set => medecin = value; }
        public int Id_patient { get => id_patient; set => id_patient = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
    }
}
