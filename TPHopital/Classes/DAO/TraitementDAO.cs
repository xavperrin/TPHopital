using System;
using System.Collections.Generic;

using System.Data.SqlClient;

namespace TPHopital.Classes.DAO
{
    public abstract class TraitementDAO : IDAO<Traitement, int>
    {
        protected string TABLE="Traitement";
        protected SqlCommand createCmd;
        protected SqlCommand retrieveCmd;
        protected SqlCommand updateCmd;
        protected SqlCommand deleteCmd;
        protected SqlConnection connection;
        protected SqlCommand listAllCmd;   

        public TraitementDAO()
        {
            connection = Connection.Instance;
            deleteCmd = new SqlCommand("DELETE FROM "+TABLE+" WHERE id_traitement=@id ", connection);
        }

        public  bool Create(Traitement t)
        {
            
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            deleteCmd.Parameters.Clear();
            deleteCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            if (deleteCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Suppression effecutée");
                deleted = true;
            }

            deleteCmd.Dispose();
            connection.Close();
            return deleted;
        }

        public List<Traitement> ListAll()
        {
            throw new NotImplementedException();
        }

        public Traitement Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Traitement t, int id)
        {
            throw new NotImplementedException();
        }
    }
}