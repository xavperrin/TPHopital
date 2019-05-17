using System;
using System.Collections.Generic;
using System.Text;
using TPHopital.Classes.Facades;

namespace TPHopital.Classes
{
    class TestAdd
    {

        public static int RandomNumber()
        {
            Random random = new Random();
            return random.Next(1000);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static void Main(string[] args)
        {
            FacadeMetier.Init();
            Medecin m = new Medecin();
            m.Nom_medecin = "Muflin"+ RandomNumber();
            m.Prenom_medecin = "Guitrigneux"+ RandomNumber();
            m.Tel_medecin = "4444545";




            FacadeMetier.Add(m);




            Patient patient = new Patient();
            patient.NomPatient = "Nom" + RandomNumber();
            patient.PrenomPatient="Prenom"+ RandomNumber();
            patient.DateNaissance=new DateTime(RandomNumber(1950, 2018), 12, 12);
            patient.Sexe = "Homme";

            
           


            Console.ReadLine();
        }
    }
}
