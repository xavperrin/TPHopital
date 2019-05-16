using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TPHopital.Classes.DAO
{
    public class Rendez_VousDAO : IDAO<Rendez_Vous, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;

        public Rendez_VousDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Rendez_Vous (codeRDV, medecin, date_RDV, service, patient_ID) values(@codeRDV, @medecin, @date_RDV, @service, @r.patient_ID)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Rendez_Vous where r.patient_ID like @search", connection);
            updateCmd = new SqlCommand("UPDATE Rendez_Vous SET codeRDV='@codeRDV', medecin='@medecin', date_RDV='@date_RDV', r.patient_ID='@r.patient_ID' WHERE r.patient_ID=@r.patient_ID", connection);
            deleteCmd = new SqlCommand("DELETE FROM Rendez_Vous WHERE r.patient_ID=@r.patient_ID ", connection);
            listAllCmd = new SqlCommand("SELECT * FROM Rendez_Vous", connection);
        }
        public void Create(Rendez_Vous r)
        {
            createCmd.Parameters.Add(new SqlParameter("@codeRDV", r.CodeRDV));
            createCmd.Parameters.Add(new SqlParameter("@medecin", r.Medecin));
            createCmd.Parameters.Add(new SqlParameter("@date_RDV", r.Date));
            createCmd.Parameters.Add(new SqlParameter("@service", r.Status));
            createCmd.Parameters.Add(new SqlParameter("@patient_ID", r.Id_patient));

            connection.Open();

            if (createCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Insertion effectuée");
            }

            createCmd.Dispose();
            connection.Close();
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
                rdv.Status = (ServiceStatus)reader.GetInt32(3);
                rdv.Id_patient = reader.GetInt32(4);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return rdv;
        }

        public void Update(Rendez_Vous rdv, int codeRDV)
        {
            updateCmd.Parameters.Add(new SqlParameter("@medecin", rdv.Medecin));
            updateCmd.Parameters.Add(new SqlParameter("@date_RDV", rdv.Date));
            updateCmd.Parameters.Add(new SqlParameter("@service", rdv.Status));
            updateCmd.Parameters.Add(new SqlParameter("@patient_ID", rdv.Id_patient));

            updateCmd.Parameters.Add(new SqlParameter("@codeRDV", codeRDV));

            connection.Open();
            updateCmd.ExecuteNonQuery();
            updateCmd.Dispose();
            connection.Close();
        }


        public void Delete(int codeRDV)
        {
            deleteCmd.Parameters.Add(new SqlParameter("@codeRDV", codeRDV));
            connection.Open();
            if (deleteCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Suppression effectuée");
            }
            deleteCmd.Dispose();
            connection.Close();
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
                    Status = (ServiceStatus)reader.GetInt32(3),
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








