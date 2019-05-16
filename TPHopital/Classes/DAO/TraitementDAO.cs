using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TPHopital.Classes.DAO
{
    abstract class TraitementDAO : IDAO<Traitement, Int32>
    {
        protected SqlCommand createCmd;
        protected SqlCommand retrieveCmd;
        protected SqlCommand updateCmd;
        protected SqlCommand deleteCmd;
        protected SqlConnection connection;
        protected SqlCommand listAllCmd;
        



        public TraitementDAO()
        {
            connection = Connection.Instance;
            //createCmd = new SqlCommand("INSERT INTO Traitement (nom_medecin, prenom_medecin, tel_medecin) values(@nom, @prenom, @tel)", connection);
            //retrieveCmd = new SqlCommand("SELECT * FROM Traiement where id_traitement like @search", connection);
            //updateCmd = new SqlCommand("UPDATE Medecin SET nom_medecin='@nom', prenom_medecin='@prenom', tel_medecin='@tel' WHERE id=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM traitement WHERE id_traitement=@id ", connection);
            //retrieveAll = new SqlCommand("SELECT * FROM Traitement");
        }

        public abstract void Create(Traitement traitement);
        

        public void Delete(int id)
        {
            deleteCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            if (deleteCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Suppression effecutée");
            }

            deleteCmd.Dispose();
            connection.Close();
        }

        public abstract List<Traitement> ListAll();


        public abstract Traitement Retrieve(int id);


        public abstract void Update(Traitement traitement, int id);
       
    }
}