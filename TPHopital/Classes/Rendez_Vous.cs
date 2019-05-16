using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes
{
    public class Rendez_Vous
    {
        private int codeRDV;
        private string medecin;
        private int id_patient;
        private DateTime Date;
        private ServiceStatus status;

        public int CodeRDV { get => codeRDV; set => codeRDV = value; }
        public string Medecin { get => medecin; set => medecin = value; }
        public int Id_patient { get => id_patient; set => id_patient = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        public ServiceStatus Status { get => status; set => status = value; }


        public Rendez_Vous()
        {
        }

        public Rendez_Vous(int codeRDV, string medecin, int id_patient, DateTime Date1, ServiceStatus status)
        {
            CodeRDV = codeRDV;
            Medecin = medecin;
            Id_patient = id_patient;
            Date1 = Date;
            Status = status;
        }

        public override string ToString()
        {
            return "Rendez_Vous (Code RendezVous :" + CodeRDV + "Nom du Medecin:" + Medecin + " Id patient :" + Id_patient + " Date du Rdv:" + Date1 + " Service :" + Status + ")";
        }
    }
}

public enum ServiceStatus
{
    Cardiologie,
    Neurologie,
    Hematologie,
    Pneumologie,
    Nephrologie,
    Maternite,
    Osteopathie,
    Oncologie
}

