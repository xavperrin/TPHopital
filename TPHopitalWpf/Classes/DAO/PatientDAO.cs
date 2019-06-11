using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TPHopitalWpfEF.Classes.DAO
{
    public class PatientDAO : IDAO<Patient, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;

        public PatientDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Patient (NomPatient, PrenomPatient, Date_Naissance, Sexe, Adresse, SituationFamiliale, AssuranceMedicale, CodeAssurance, Tel, NomPere, NomMere, NomP_a_prevenir, TelP_a_prevenir) values (@nom, @prenom, @date, @sexe, @adresse, @situation, @assurance, @codeA, @tel, @nomP, @nomM, @nomPaP, @telPaP)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Patient where id_patient like @search", connection);
            updateCmd = new SqlCommand("UPDATE Patient SET NomPatient=@nom, PrenomPatient=@prenom, Date_Naissance=@date, Sexe=@sexe Adresse=@adresse, SituationFamiliale=@situation, AssuranceMedicale=@assurance, CodeAssurance=@codeA Tel=@tel, NomPere=@nomP, NomMere=@nomM, NomP_a_prevenir=@nomPaP, TelP_a_prevenir=@telPaP WHERE id_patient=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM Patient WHERE id_patient=@id", connection);
            listAllCmd = new SqlCommand("SELECT * FROM Patient", connection);
        }

        public bool Create(Patient patient)
        {

            bool created = false;
            Task t = Task.Run(() =>
            {
               
                createCmd.Parameters.Clear();

                createCmd.Parameters.Add(new SqlParameter("@nom", patient.NomPatient));
                createCmd.Parameters.Add(new SqlParameter("@prenom", patient.PrenomPatient));
                createCmd.Parameters.Add(new SqlParameter("@date", patient.DateNaissance));
                createCmd.Parameters.Add(new SqlParameter("@sexe", patient.Sexe));
                createCmd.Parameters.Add(new SqlParameter("@adresse", patient.Adresse));
                createCmd.Parameters.Add(new SqlParameter("@situation", patient.SituationFamiliale));
                createCmd.Parameters.Add(new SqlParameter("@assurance", patient.AssuranceMedicale));
                createCmd.Parameters.Add(new SqlParameter("@codeA", patient.Codeassurance));
                createCmd.Parameters.Add(new SqlParameter("@tel", patient.Tel));
                createCmd.Parameters.Add(new SqlParameter("@nomP", patient.NomPere));
                createCmd.Parameters.Add(new SqlParameter("@nomM", patient.NomMere));
                createCmd.Parameters.Add(new SqlParameter("@nomPaP", patient.Nom_P_a_prevenir));
                createCmd.Parameters.Add(new SqlParameter("@telPaP", patient.Tel_P_a_prevenir));

                lock (new object())
                {
                    connection.Open();
                    Console.WriteLine(patient);
                    //Console.ReadLine();
                    if (createCmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Insertion effecutée" + patient);
                        created = true;
                    }
                    else throw new InsertPatientException("Insertion n'a pas réussie" + patient);

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

        public Patient Retrieve(int id)
        {
            Task<Patient> t = Task.Run(() =>
            {
                Patient patient = new Patient();

                retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

                lock (new object())
                {
                    connection.Open();
                    SqlDataReader reader = retrieveCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        patient.Id_Patient = reader.GetInt32(0);
                        patient.NomPatient = reader.GetString(1);
                        patient.PrenomPatient = reader.GetString(2);
                        patient.DateNaissance = reader.GetDateTime(3);
                        patient.Sexe = reader.GetString(4);
                        patient.Adresse = reader.GetString(5);
                        patient.SituationFamiliale = reader.GetString(6);
                        patient.AssuranceMedicale = reader.GetString(7);
                        patient.Codeassurance = reader.GetString(8);
                        patient.Tel = reader.GetString(9);
                        patient.NomPere = reader.GetString(10);
                        patient.NomMere = reader.GetString(11);
                        patient.Nom_P_a_prevenir = reader.GetString(12);
                        patient.Tel_P_a_prevenir = reader.GetString(13);
                    }

                    reader.Close();
                    retrieveCmd.Dispose();
                    connection.Close();

                    return patient;
                }
            });

            return t.Result;
        }

        public bool Update(Patient patient, int id)
        {
            bool updated = false;
            Task t = Task.Run(() =>
            {
                updateCmd.Parameters.Clear();
                updateCmd.Parameters.Add(new SqlParameter("@nom", patient.NomPatient));
                updateCmd.Parameters.Add(new SqlParameter("@prenom", patient.PrenomPatient));
                updateCmd.Parameters.Add(new SqlParameter("@date", patient.DateNaissance));
                updateCmd.Parameters.Add(new SqlParameter("@sexe", patient.Sexe));
                updateCmd.Parameters.Add(new SqlParameter("@adresse", patient.Adresse));
                updateCmd.Parameters.Add(new SqlParameter("@situation", patient.SituationFamiliale));
                updateCmd.Parameters.Add(new SqlParameter("@assurance", patient.AssuranceMedicale));
                updateCmd.Parameters.Add(new SqlParameter("@codeA", patient.Codeassurance));
                updateCmd.Parameters.Add(new SqlParameter("@tel", patient.Tel));
                updateCmd.Parameters.Add(new SqlParameter("@nomP", patient.NomPere));
                updateCmd.Parameters.Add(new SqlParameter("@nomM", patient.NomMere));
                updateCmd.Parameters.Add(new SqlParameter("@nomPaP", patient.Nom_P_a_prevenir));
                updateCmd.Parameters.Add(new SqlParameter("@telPaP", patient.Tel_P_a_prevenir));

                lock (new object())
                {
                    updateCmd.Parameters.Add(new SqlParameter("@id", id));

                    connection.Open();
                    if (updateCmd.ExecuteNonQuery() > 0)
                        updated = true;
                    updateCmd.Dispose();
                    connection.Close();
                    
                }
            });
            return updated;
        }

        public List<Patient> ListAll()
        {
            Task<List<Patient>> t = Task.Run(new Func<List<Patient>>(() =>
            {
                List<Patient> listPatient = new List<Patient>();

                lock (new object())
                {
                    connection.Open();
                    SqlDataReader reader = listAllCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        listPatient.Add(new Patient
                        {
                            Id_Patient = reader.GetInt32(0),
                            NomPatient = reader.GetString(1),
                            PrenomPatient = reader.GetString(2),
                            DateNaissance = reader.GetDateTime(3),
                            Sexe = reader.GetString(4),
                            Adresse = reader.GetString(5),
                            SituationFamiliale = reader.GetString(6),
                            AssuranceMedicale = reader.GetString(7),
                            Codeassurance = reader.GetString(8),
                            Tel = reader.GetString(9),
                            NomPere = reader.GetString(10),
                            NomMere = reader.GetString(11),
                            Nom_P_a_prevenir = reader.GetString(12),
                            Tel_P_a_prevenir = reader.GetString(13)
                        });
                    }

                    reader.Close();
                    retrieveCmd.Dispose();
                    connection.Close();

                    return listPatient;
                }
            }));
            return t.Result;
        }
    }
}
