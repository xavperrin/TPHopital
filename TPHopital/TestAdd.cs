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
            return random.Next();
        }

        static void Main(string[] args)
        {
            FacadeMetier.Init();
            Medecin m = new Medecin();
            m.Nom_medecin = "Muflin"+ RandomNumber();
            m.Prenom_medecin = "Guitrigneux"+ RandomNumber();
            m.Tel_medecin = "4444545"+ RandomNumber();




            FacadeMetier.Add(m);
            Patient patient = new Patient();
           


            Console.ReadLine();
        }
    }
}
