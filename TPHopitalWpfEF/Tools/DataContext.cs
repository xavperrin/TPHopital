using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPHopitalWpf.Classes;
using TPHopitalWpf.Classes.DTOs;

namespace TPHopitalWpfEF.Tools
{
    public class DataContext : DbContext
    {
        private static object _lock = new object();
        private static DataContext _instance = null;
        private static readonly string connectionString = @"Data Source=(localDb)\HopitalDB;Integrated Security=True";

        public static DataContext Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DataContext();
                    return _instance;
                }
            }
        }

        private DataContext() : base(connectionString)
        {

        }

        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Hospitalisation> Hospitalisations { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Rendez_Vous> Rendez_Vouss { get; set; }
        public DbSet<Traitement> Traitements { get; set; }
        public DbSet<Type_Consultation> Type_Consultations { get; set; }
    }
}
