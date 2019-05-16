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
            FacadeMetier façade = new FacadeMetier();
            Medecin m = new Medecin();
            façade.ajouter((DTO)m);

            Console.ReadLine();
        }
    }
}
