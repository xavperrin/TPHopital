﻿using System;
using System.Data.SqlClient;


namespace TPHopital.Classes.DAO
{
    class PatientDAO : IDAO<Patient, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlConnection connection;

        public PatientDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Patient (nom, prenom, date_naissance, sexe, adresse, situation_familiale) values(@nom, @prenom, @date_naissance, @sexe, @adresse, @situation_familiale)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Patient where nom like @search OR prenom like @search", connection);
            updateCmd = new SqlCommand("UPDATE Patient SET nom='@nom', prenom='@prenom', tel='@tel' WHERE id=@id");
            deleteCmd = new SqlCommand("DELETE FROM Patient WHERE id=@id ");
        }

        public void Create(Patient patient)
        {
            createCmd.Parameters.Add(new SqlParameter("@nom", patient.NomPatient));
            createCmd.Parameters.Add(new SqlParameter("@prenom", patient.PrenomPatient));
            createCmd.Parameters.Add(new SqlParameter("@date_naissance", patient.DateNaissance));
            createCmd.Parameters.Add(new SqlParameter("@sexe", patient.Sexe));
            /**
             etc
             **/

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
            throw new NotImplementedException();
        }

        public Patient Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient patient, int id)
        {
            throw new NotImplementedException();
        }
    }
}
