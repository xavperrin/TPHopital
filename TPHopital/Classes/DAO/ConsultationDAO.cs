using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TPHopital.Classes.DAO
{
    public class ConsultationDAO : IDAO<Consultation, Int32>
    {

        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;

        public ConsultationDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Consultation (date_consultation, synthese, type_consultation_id," +
                                      " rdv_code, prescription_id, medecin_id) values(@date, @synthese," +
                                      " @type, @rdv_code, @prescription_id, @medecin_id)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Consultation where id_consultation like @search", connection);
            listAllCmd = new SqlCommand("SELECT * FROM Consultation", connection);
            updateCmd = new SqlCommand("UPDATE Consultation SET date_consultation='@date'," +
                                      " synthese='@synthese', type_consultation_id='@type', rdv_code='@rdv_code'," +
                                      " prescription_id='@prescription_id', medecin_id='@medecin_id' WHERE id=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM Consultation WHERE id=@id ", connection);
        }

        public void Create(Consultation consultation)
        {
            createCmd.Parameters.Add(new SqlParameter("@date", consultation.Date_consultation));
            createCmd.Parameters.Add(new SqlParameter("@synthese", consultation.Synthese));
            createCmd.Parameters.Add(new SqlParameter("@type", consultation.Type_consultation_id));
            createCmd.Parameters.Add(new SqlParameter("@rdv_code", consultation.Rdv_code));
            createCmd.Parameters.Add(new SqlParameter("@prescription_id", consultation.Prescription_id));
            createCmd.Parameters.Add(new SqlParameter("@medecin_id", consultation.Medecin_id));

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

        

        public Consultation Retrieve(int id)
        {
            Consultation consultation = new Consultation();

            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();


            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                consultation.Id_consultation = reader.GetInt32(0);
                consultation.Date_consultation = reader.GetDateTime(1);
                consultation.Synthese = reader.GetString(2);
                consultation.Type_consultation_id = reader.GetInt32(3);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return consultation;
        }

        public void Update(Consultation consultation, int id)
        {
            updateCmd.Parameters.Add(new SqlParameter("@date", consultation.Date_consultation));
            updateCmd.Parameters.Add(new SqlParameter("@synthese", consultation.Synthese));
            updateCmd.Parameters.Add(new SqlParameter("@type", consultation.Type_consultation_id));
            updateCmd.Parameters.Add(new SqlParameter("@rdv_code", consultation.Rdv_code));
            updateCmd.Parameters.Add(new SqlParameter("@prescription_id", consultation.Prescription_id));
            updateCmd.Parameters.Add(new SqlParameter("@medecin_id", consultation.Medecin_id));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            Connection.Instance.Open();
            updateCmd.ExecuteNonQuery();
            updateCmd.Dispose();
            connection.Close();
        }

        public List<Consultation> ListAll()
        {
            List<Consultation> listConsultation = new List<Consultation>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            if (reader.Read())
            {
                listConsultation.Add(new Consultation
                {
                    Id_consultation = reader.GetInt32(0),
                    Date_consultation = reader.GetDateTime(1),
                    Synthese = reader.GetString(2),
                    Type_consultation_id = reader.GetInt32(3)
                });
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return listConsultation;
        }
    }
}
