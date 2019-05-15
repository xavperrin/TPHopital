using System;
using TPHopital.Classes;
using TPHopital.Classes.DAO;

namespace TPHopital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Nom medecin");
            string strNom= Console.ReadLine();
            string strPrenom = "Bourgneuf";
            Medecin m = new Medecin(strNom, strPrenom, 15485454);
            MedecinDAO dao_med = new MedecinDAO();
            dao_med.Create(m);

        }
    }
}
