using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using TPHopitalWpfEF.Classes.DTOs;
using System.Threading.Tasks;

namespace TPHopitalWpfEF.Classes.DAO
{
    public class ConsultationDAO : IDAO<Consultation, int>
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
            String insert = "INSERT INTO Consultation(date_consultation, synthese, type_consultation_id," +
                                      " rdv_code, prescription_id, medecin_id) values(@date, @synthese," +
                                      " @type, @rdv_code, @prescription_id, @medecin_id)";
            createCmd = new SqlCommand(insert, connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Consultation where id_consultation like @search", connection);
            listAllCmd = new SqlCommand("SELECT * FROM Consultation", connection);
            string update = "UPDATE Consultation SET date_consultation=@date," +
                                      " synthese=@synthese, type_consultation_id=@type, rdv_code=@rdv_code," +
                                      " prescription_id=@prescription_id, medecin_id=@medecin_id WHERE id_consultation=@id";
            updateCmd = new SqlCommand(update, connection);
            deleteCmd = new SqlCommand("DELETE FROM Consultation WHERE id_consultation=@id ", connection);
        }

        public bool Create(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));
            bool created = false;
            Task t = Task.Run(() =>
            {
                createCmd.Parameters.Add(new SqlParameter("@date", consultation.Date_consultation));
                createCmd.Parameters.Add(new SqlParameter("@synthese", consultation.Synthese));
                createCmd.Parameters.Add(new SqlParameter("@type", consultation.Type_consultation_id));
                createCmd.Parameters.Add(new SqlParameter("@rdv_code", consultation.Rdv_code));
                createCmd.Parameters.Add(new SqlParameter("@prescription_id", consultation.Prescription_id));
                createCmd.Parameters.Add(new SqlParameter("@medecin_id", consultation.Medecin_id));

                lock (new object())
                {
                    connection.Open();

                    if (createCmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Insertion effecutée");
                        created = true;
                    }

                    createCmd.Dispose();
                    connection.Close();
                }
            });
            t.Wait();
            return created;
        }

        public bool Delete(int id)
        {
           bool deleted = false;
            Task.Run(() =>
            {
                deleteCmd.Parameters.Add(new SqlParameter("@id", id));
                lock (new object())
                {
                    connection.Open();

                    if (deleteCmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Suppression effecutée");
                        deleted = true;
                    }

                    deleteCmd.Dispose();
                    connection.Close();
                }
            });
            return deleted;
        }


        public Consultation Retrieve(int id)
        {
            Task<Consultation> t = Task.Run(() =>
            {
                Consultation consultation = new Consultation();

                retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

                lock (new object())
                {
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
            });

            return t.Result;
        }

        public bool Update(Consultation consultation, int id)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));
            bool updated = false;
            Task t = Task.Run(() =>
            {
                updateCmd.Parameters.Add(new SqlParameter("@date", consultation.Date_consultation));
                updateCmd.Parameters.Add(new SqlParameter("@synthese", consultation.Synthese));
                updateCmd.Parameters.Add(new SqlParameter("@type", consultation.Type_consultation_id));
                updateCmd.Parameters.Add(new SqlParameter("@rdv_code", consultation.Rdv_code));
                updateCmd.Parameters.Add(new SqlParameter("@prescription_id", consultation.Prescription_id));
                updateCmd.Parameters.Add(new SqlParameter("@medecin_id", consultation.Medecin_id));

                updateCmd.Parameters.Add(new SqlParameter("@id", id));

                lock (new object())
                {
                    Connection.Instance.Open();
                    if (updateCmd.ExecuteNonQuery() > 0)
                        updated = true;
                    updateCmd.Dispose();
                    connection.Close();
                }
            });
            return updated;
        }

        public List<Consultation> ListAll()
        {
            Task<List<Consultation>> t = Task.Run(new Func<List<Consultation>>(() =>
            {
                List<Consultation> listConsultation = new List<Consultation>();

                lock (new object())
                {
                    connection.Open();
                    SqlDataReader reader = listAllCmd.ExecuteReader();

                    while (reader.Read())
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
            }));

            return t.Result;
        }
    }
}
