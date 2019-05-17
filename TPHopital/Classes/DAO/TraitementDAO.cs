using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TPHopital.Classes.DAO
{
    public abstract class TraitementDAO : IDAO<Traitement, int>
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
            deleteCmd = new SqlCommand("DELETE FROM traitement WHERE id_traitement=@id ", connection);
        }

        public  void Create(Traitement t)
        {
            throw new NotImplementedException();
        }

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

        public List<Traitement> ListAll()
        {
            throw new NotImplementedException();
        }

        public Traitement Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Traitement t, int id)
        {
            throw new NotImplementedException();
        }
    }
}