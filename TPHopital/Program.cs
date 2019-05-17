using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //FacadeMetier facade = new FacadeMetier();
            Medecin m = new Medecin();
            m.Nom_medecin = "Muflin";
            m.Prenom_medecin = "Guitrigneux";
            m.Tel_medecin = 4444545;
            FacadeMetier.Add(m);
            Console.ReadLine();
        }

        static void Menu()
        {
            int choix = 4;
            do
            {
                Console.WriteLine("1- Liste de patients");
                Console.WriteLine("2- Liste de rendez vous");
                Console.WriteLine("3- Ajouter rendez vous ");
                Console.WriteLine("0- Exit");
                try
                {
                    choix = Convert.ToInt32(Console.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            GetPatients();
                            break;
                        case 2:
                            GetRendez_Vous();
                            break;
                        case 3:
                            AddRendezVous();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (choix != 0);
        }


        static void GetPatients()
        {
            Console.Clear();
            

            List<Patient> liste = new PatientDAO().ListAll();
            if (liste.Count > 0)
            {
                Console.WriteLine("------Liste des patients------");
                foreach (Patient p in liste)
                {
                    Console.WriteLine(p);
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                Console.WriteLine("Aucun patient trouvé");
            }
            MenuPatient();
        }

        static void GetRendez_Vous()
        {
            Console.Clear();


            List<Rendez_Vous> liste = new Rendez_VousDAO().ListAll();
            if (liste.Count > 0)
            {
                Console.WriteLine("------Liste des Rendez_Vous------");
                foreach (Rendez_Vous r in liste)
                {
                    Console.WriteLine(r);
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                Console.WriteLine("Aucun rendez vous trouvé");
            }
            MenuPatient();
        }

        private static void AddRendezVous()
        {
            Console.Clear();
            Rendez_Vous newRdv = new Rendez_VousDAO().Create(Rendez_Vous rdv);
            
                


        }

        static void MenuPatient()
        {
            int choix = 4;
            do
            {
                Console.WriteLine("1- Nouveau patient");
                Console.WriteLine("2- Information patient");
                Console.WriteLine("3- Ajouter rendez vous");
                Console.WriteLine("0- Exit");
                try
                {
                    choix = Convert.ToInt32(Console.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            NewPatient();
                            break;
                        case 2:
                            InformationPatient();
                            break;
                        case 3:
                            AddRendez_Vous();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (choix != 0);
        }
        static void NewPatient()
        {

        }
        static void InformationPatient()
        {
            Console.Clear();

            List<Patient> liste = new PatientDAO().Retrieve();
            if (liste.Count > 0)
            {
                Console.WriteLine("------Informations Patient------");
                foreach (Rendez_Vous r in liste)
                {
                    Console.WriteLine(r);
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                Console.WriteLine("Aucune information");
            }
            MenuPatient();
        }
        static void AddRendez_Vous()
        {
        }

    }
}
