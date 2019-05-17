﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TPHopital.Classes.DAO
{
    public class Type_ConsultationDAO : IDAO<Type_Consultation, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;

        public Type_ConsultationDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Type_Consultation (type_consultation, prix_consultation) values(@type, @date)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Type_Consultation where id_type_consultation like @search", connection);
            updateCmd = new SqlCommand("UPDATE Type_Consultation SET type_consultation='@type', prix_consultation='@prix' WHERE id_type_consultation=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM Type_Consultation WHERE id_type_consultation=@id ", connection);
            listAllCmd = new SqlCommand("SELECT * FROM Type_Consultation", connection);
        }

        public void Create(Type_Consultation type_consultation)
        {
            createCmd.Parameters.Add(new SqlParameter("@type", type_consultation.Type_consultation));
            createCmd.Parameters.Add(new SqlParameter("@prix", type_consultation.Prix_consultation));
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

        public Type_Consultation Retrieve(int id)
        {
            Type_Consultation tc = new Type_Consultation();

            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();

            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                tc.Id_type_consultation = reader.GetInt32(0);
                tc.Type_consultation = reader.GetString(1);
                tc.Prix_consultation = reader.GetDecimal(2);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return tc;
        }

        public void Update(Type_Consultation tc, int id)
        {
            updateCmd.Parameters.Add(new SqlParameter("@type", tc.Type_consultation));
            updateCmd.Parameters.Add(new SqlParameter("@prix", tc.Prix_consultation));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            updateCmd.ExecuteNonQuery();
            updateCmd.Dispose();
            connection.Close();
        }

        public List<Type_Consultation> ListAll()
        {
            List<Type_Consultation> listType_Consultation = new List<Type_Consultation>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            while (reader.Read())
            {
                listType_Consultation.Add(new Type_Consultation
                {
                    Id_type_consultation = reader.GetInt32(0),
                    Type_consultation = reader.GetString(1),
                    Prix_consultation = reader.GetDecimal(2)
                });
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return listType_Consultation;
        }
    }
}
