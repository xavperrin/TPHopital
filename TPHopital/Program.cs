using System;
using System.Collections.Generic;
using TPHopital.Classes;
using TPHopital.Classes.DAO;
using TPHopital.Classes.Facades;
using TPHopital.Classes.DTOs;

namespace TPHopital
{
    class Program
    {
        static void Main(string[] args)
        {
            FacadeMetier.Init();
            Medecin m= new Medecin();
            m.Nom_medecin = "Muflin";
            m.Prenom_medecin = "Guitrigneux";
            m.Tel_medecin = "4444545";
            FacadeMetier.Add(m);
            Console.ReadLine();
        }
    }
}
