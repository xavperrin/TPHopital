using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TPHopital.Classes.DAO
{
    public class FactureDAO : IDAO<Facture, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;

        public FactureDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Facture (date_facture, total, Admission_ID) values(@date, @total, @idAdmission)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Facture where id_facture like @search", connection);
            updateCmd = new SqlCommand("UPDATE Facture SET date_facture='@date', total='@total', Admission_ID='@idAdmission' WHERE id=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM Facture WHERE id=@id ", connection);
            listAllCmd = new SqlCommand("SELECT * FROM Facture", connection);
        }

        public void Create(Facture facture)
        {
            createCmd.Parameters.Add(new SqlParameter("@date", facture.Date_facture));
            createCmd.Parameters.Add(new SqlParameter("@total", facture.Total));
            createCmd.Parameters.Add(new SqlParameter("@idAdmission", facture.Admission_id));
            connection.Open();

            if (createCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Insertion effecutée");
            }

            createCmd.Dispose();
            connection.Close();
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

        public Facture Retrieve(int id)
        {
            Facture facture = new Facture();

            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();

            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                facture.Id_facture = reader.GetInt32(0);
                facture.Date_facture = reader.GetDateTime(1);
                facture.Total = reader.GetFloat(2);
                facture.Admission_id = reader.GetInt32(3);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return facture;
        }

        public void Update(Facture facture, int id)
        {
            updateCmd.Parameters.Add(new SqlParameter("@date", facture.Date_facture));
            updateCmd.Parameters.Add(new SqlParameter("@total", facture.Total));
            updateCmd.Parameters.Add(new SqlParameter("@admission_id", facture.Admission_id));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            updateCmd.ExecuteNonQuery();
            updateCmd.Dispose();
            connection.Close();
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
                    Total = reader.GetFloat(2),
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
