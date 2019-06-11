using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TPHopitalWpfEF.Classes.DAO
{
    public class Rendez_VousDAO : IDAO<Rendez_Vous, Int32>
    {
        private SqlCommand createCmd;
        private readonly SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private readonly SqlCommand deleteCmd;
        private readonly SqlCommand listAllCmd;
        private SqlConnection connection;

        private string TABLE="Rendez_Vous";
        private string COLUMNS = "codeRDV, medecin, date_RDV, service, patient_ID"; 

        public Rendez_VousDAO()
        {
            connection = Connection.Instance;
            /* A REVOIR */
            createCmd = new SqlCommand("INSERT INTO "+ TABLE + " (medecin, date_RDV, service, patient_ID) values(@codeRDV, @medecin, @date_RDV, @service, @patient_ID)", connection);
            retrieveCmd = new SqlCommand("SELECT "+COLUMNS+" FROM "+TABLE+" WHERE patient_ID like @search", connection);
            updateCmd = new SqlCommand("UPDATE " + TABLE + " SET medecin=@medecin, date_RDV=@date_RDV, patient_ID=@patient_ID WHERE patient_ID=@patient_ID", connection);
            deleteCmd = new SqlCommand("DELETE FROM " + TABLE + " WHERE patient_ID=@patient_ID ", connection);
            listAllCmd = new SqlCommand("SELECT " + COLUMNS + " FROM " + TABLE , connection);
        }
        public bool Create(Rendez_Vous rdv)
        {
            bool created = false;
            createCmd.Parameters.Clear();
            createCmd.Parameters.Add(new SqlParameter("@codeRDV", rdv.CodeRDV));
            createCmd.Parameters.Add(new SqlParameter("@medecin", rdv.Medecin));
            createCmd.Parameters.Add(new SqlParameter("@date_RDV", rdv.Date));
            createCmd.Parameters.Add(new SqlParameter("@service", rdv.Service));
            createCmd.Parameters.Add(new SqlParameter("@patient_ID", rdv.Id_patient));

            connection.Open();

            if (createCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Insertion effectuée");
                created = true;
            }

            createCmd.Dispose();
            connection.Close();
            return created;
        }

        public Rendez_Vous Retrieve(int codeRDV)
        {
            Rendez_Vous rdv = new Rendez_Vous();
            retrieveCmd.Parameters.Add(new SqlParameter("@search", codeRDV));
            connection.Open();
            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                rdv.CodeRDV = reader.GetInt32(0);
                rdv.Medecin = reader.GetString(1);
                rdv.Date = reader.GetDateTime(2);
                rdv.Service = (ServiceEnum)reader.GetInt32(3);
                rdv.Id_patient = reader.GetInt32(4);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return rdv;
        }

        public bool Update(Rendez_Vous rdv, int codeRDV)
        {
            bool updated = false;
            updateCmd.Parameters.Clear();
            updateCmd.Parameters.Add(new SqlParameter("@medecin", rdv.Medecin));
            updateCmd.Parameters.Add(new SqlParameter("@date_RDV", rdv.Date));
            updateCmd.Parameters.Add(new SqlParameter("@service", rdv.Service));
            updateCmd.Parameters.Add(new SqlParameter("@patient_ID", rdv.Id_patient));

            updateCmd.Parameters.Add(new SqlParameter("@codeRDV", codeRDV));

            connection.Open();
            if (updateCmd.ExecuteNonQuery() > 0)
                updated = true;
            updateCmd.Dispose();
            connection.Close();
            return updated;
        }


        public bool Delete(int codeRDV)
        {
            bool deleted = false;
            deleteCmd.Parameters.Add(new SqlParameter("@codeRDV", codeRDV));
            connection.Open();
            if (deleteCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Suppression effectuée");
                deleted = true;
            }
            deleteCmd.Dispose();
            connection.Close();
            return deleted;
        }

        public List<Rendez_Vous> ListAll()
        {
            List<Rendez_Vous> listRdv = new List<Rendez_Vous>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            while (reader.Read())
            {
                listRdv.Add(new Rendez_Vous
                {
                    CodeRDV = reader.GetInt32(0),
                    Medecin = reader.GetString(1),
                    Date = reader.GetDateTime(2),
                    Service = (ServiceEnum)reader.GetInt32(3),
                    Id_patient = reader.GetInt32(4)
                });
            }
            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();
            return listRdv;
        }
    }
}








