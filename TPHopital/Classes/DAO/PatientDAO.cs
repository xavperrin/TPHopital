using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace TPHopital.Classes.DAO
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
            createCmd = new SqlCommand("INSERT INTO Patient (NomPatient, PrenomPatient, Date_Naissance, Sexe, Adresse," +
                "SituationFamiliale, AssuranceMedicale, CodeAssurance," +
                "Tel, NomPere, NomMere, NomP_a_prevenir, TelP_a_prevenir) values(" +
                "@nom, @prenom, @date, @sexe, @adresse, " +
                "@situation, @assurance, @codeA, " +
                "@tel, @nomP, @nomM, @nomPaP, @telPaP)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Patient where id_patient like @search", connection);
            updateCmd = new SqlCommand("UPDATE Patient SET " +
                "NomPatient='@nom', PrenomPatient='@prenom', Date_Naissance='@date', Sexe='@sexe'" +
                "Adresse='@adresse', SituationFamiliale='@situation', AssuranceMedicale='@assurance', CodeAssurance='@codeA'" +
                "Tel='@tel', NomPere='@nomP', NomMere='@nomM', NomP_a_prevenir='@nomPaP', TelP_a_prevenir='@telPaP'" +
                "WHERE id_patient=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM Patient WHERE id_patient=@id ", connection);
            listAllCmd = new SqlCommand("SELECT * FROM Patient", connection);
        }

        public void Create(Patient patient)
        {
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

        public Patient Retrieve(int id)
        {
            Patient patient = new Patient();

            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

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

        public void Update(Patient patient, int id)
        {
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

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            updateCmd.ExecuteNonQuery();
            updateCmd.Dispose();
            connection.Close();
        }

        public List<Patient> ListAll()
        {
            List<Patient> listPatient = new List<Patient>();

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
    }
}
