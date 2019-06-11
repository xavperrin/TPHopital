using System;
using System.Collections.Generic;
using System.Text;
using TPHopitalWpfEF.Classes.DTOs;

namespace TPHopitalWpfEF.Classes
{
    public class Rendez_Vous :DTO
    {
        private int codeRDV;
        private string medecin;
        private int id_patient;
        private DateTime date;
        private ServiceEnum service;

        public int CodeRDV { get => codeRDV; set => codeRDV = value; }
        public string Medecin { get => medecin; set => medecin = value; }
        public int Id_patient { get => id_patient; set => id_patient = value; }
        public DateTime Date { get => date; set => date = value; }
        public ServiceEnum Service { get => service; set => service = value; }

        public Rendez_Vous()
        {
        }

        public Rendez_Vous(int codeRDV, string medecin, int id_patient, DateTime date, ServiceEnum service)
        {
            CodeRDV = codeRDV;
            Medecin = medecin;
            Id_patient = id_patient;
            Date = date;
            Service = service;
        }

        public override string ToString()
        {
            return "Rendez_Vous (Code Rendez-Vous :" + CodeRDV + "Nom du Medecin:" + Medecin + " Id patient :" + Id_patient + " Date du Rdv:" + Date + " Service :" + Service + ")";
        }

        public override bool CheckData()
        {
             if (Enum.IsDefined(typeof(ServiceEnum), Service))
                return false;
            if (medecin == "")
                return false;
            if (medecin == null)
                return false;
            if (id_patient <0)
                return false;
            if (date == null)
                return false;
            else return true;
        }
    }
}

public enum ServiceEnum
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

