using System;
using System.Collections.Generic;
using System.Text;
using TPHopital.Classes.DTOs;

namespace TPHopital.Classes
{
    public class Rendez_Vous :DTO
    {
        private int codeRDV;
        private string medecin;
        private int id_patient;
        private DateTime date;
        private ServiceStatus status;

        public int CodeRDV { get => codeRDV; set => codeRDV = value; }
        public string Medecin { get => medecin; set => medecin = value; }
        public int Id_patient { get => id_patient; set => id_patient = value; }
        public DateTime Date { get => date; set => date = value; }
        public ServiceStatus Status { get => status; set => status = value; }


        public Rendez_Vous()
        {
        }

        public Rendez_Vous(int codeRDV, string medecin, int id_patient, DateTime date, ServiceStatus status)
        {
            CodeRDV = codeRDV;
            Medecin = medecin;
            Id_patient = id_patient;
            Date = Date;
            Status = status;
        }

        public override string ToString()
        {
            return "Rendez_Vous (Code Rendez-Vous :" + CodeRDV + "Nom du Medecin:" + Medecin + " Id patient :" + Id_patient + " Date du Rdv:" + Date + " Service :" + Status + ")";
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

