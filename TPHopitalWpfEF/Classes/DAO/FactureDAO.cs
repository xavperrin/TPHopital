using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TPHopitalWpfEF.Classes.DTOs;

namespace TPHopitalWpfEF.Classes.DAO
{
    public class FactureDAO : IDAO<Facture, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;
        private string TABLE="Facture";

        public FactureDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO "+ TABLE + " (date_facture, total, Admission_ID) values(@date, @total, @idAdmission)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM "+ TABLE + " where id_facture like @search", connection);
            updateCmd = new SqlCommand("UPDATE "+TABLE+" SET date_facture=@date, total=@total, Admission_ID=@idAdmission WHERE id=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM Facture WHERE id=@id ", connection);
            listAllCmd = new SqlCommand("SELECT * FROM "+TABLE, connection);
        }

        public bool Create(Facture facture)
        {
            bool created = false;
            createCmd.Parameters.Add(new SqlParameter("@date", facture.Date_facture));
            createCmd.Parameters.Add(new SqlParameter("@total", facture.Total));
            createCmd.Parameters.Add(new SqlParameter("@idAdmission", facture.Admission_id));
            connection.Open();

            if (createCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Insertion effecutée");
                created = true;
            }

            createCmd.Dispose();
            connection.Close();
            return created;
        }

        public bool Delete(int id)
        {
            bool deleted = false;
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

        public Facture Retrieve(int id)
        {
            Facture facture = new Facture();
            retrieveCmd.Parameters.Clear();



            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();

            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                facture.Id_facture = reader.GetInt32(0);
                facture.Date_facture = reader.GetDateTime(1);
                facture.Total = reader.GetDecimal(2);
                facture.Admission_id = reader.GetInt32(3);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return facture;
        }

        public bool Update(Facture facture, int id)
        {
            bool updated = false;
            updateCmd.Parameters.Clear();
            updateCmd.Parameters.Add(new SqlParameter("@date", facture.Date_facture));
            updateCmd.Parameters.Add(new SqlParameter("@total", facture.Total));
            updateCmd.Parameters.Add(new SqlParameter("@admission_id", facture.Admission_id));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            if (updateCmd.ExecuteNonQuery() > 0)
                updated = true;

            updateCmd.Dispose();
            connection.Close();
            return updated;
        }

        public List<Facture> ListAll()
        {
            List<Facture> listFacture = new List<Facture>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            while (reader.Read())
            {
                listFacture.Add(new Facture
                {
                    Id_facture = reader.GetInt32(0),
                    Date_facture = reader.GetDateTime(1),
                    Total = reader.GetDecimal(2),
                    Admission_id = reader.GetInt32(3)
                });
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return listFacture;
        }
    }
}
