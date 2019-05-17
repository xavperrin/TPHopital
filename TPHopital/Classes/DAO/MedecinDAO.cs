﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TPHopital.Classes.DAO
{
    public class MedecinDAO : IDAO<Medecin, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;

        private SqlConnection connection;

        private string TABLE = "Medecin";
        private string COLUMNS = "nom_medecin, prenom_medecin, tel_medecin";

        public MedecinDAO() 
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Medecin ("+COLUMNS+") values(@nom, @prenom, @tel)", connection);
            retrieveCmd = new SqlCommand("SELECT id_medecin, " + COLUMNS + " FROM Medecin where id_medecin like @search", connection);
            updateCmd = new SqlCommand("UPDATE "+ TABLE + " SET nom_medecin='@nom', prenom_medecin='@prenom', tel_medecin='@tel' WHERE id=@id", connection);
            deleteCmd = new SqlCommand("DELETE FROM " + TABLE + " WHERE id_medecin=@id ", connection);
            listAllCmd = new SqlCommand("SELECT "+COLUMNS+ " FROM " + TABLE,  connection);
        }

        public void Create(Medecin medecin)
        {
            createCmd.Parameters.Add(new SqlParameter("@nom", medecin.Nom_medecin));
            createCmd.Parameters.Add(new SqlParameter("@prenom", medecin.Prenom_medecin));
            createCmd.Parameters.Add(new SqlParameter("@tel", medecin.Tel_medecin));
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
            else
                throw new ObjectNotFoundException("Aucun medecin n'a été trouvé avec l'identifiant " + id+". Il ne peut etre supprime.");

            deleteCmd.Dispose();
            connection.Close();
        }

        public Medecin Retrieve(int id)
        {
            Medecin medecin = null;

            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();


            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                medecin = new Medecin();
                medecin.Id_medecin = reader.GetInt32(0);
                medecin.Nom_medecin = reader.GetString(1);
                medecin.Prenom_medecin = reader.GetString(2);
                medecin.Tel_medecin = reader.GetString(3);
            }
            else
                throw new ObjectNotFoundException("Aucun medecin n'a été trouvé avec l'identifiant " + id);

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return medecin;


        }

        public void Update(Medecin medecin, int id)
        {

            updateCmd.Parameters.Add(new SqlParameter("@nom", medecin.Nom_medecin));
            updateCmd.Parameters.Add(new SqlParameter("@prenom", medecin.Prenom_medecin));
            updateCmd.Parameters.Add(new SqlParameter("@tel", medecin.Tel_medecin));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            if (updateCmd.ExecuteNonQuery() <= 0)
                throw new ObjectNotFoundException("Aucun medecin n'a été trouvé avec l'identifiant " + id+". Il ne peut pas etre mis à jour.");



            updateCmd.Dispose();
            connection.Close();
        }

        public List<Medecin> ListAll()
        {
            List<Medecin> listMedecin = new List<Medecin>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            while (reader.Read())
            {
                listMedecin.Add(new Medecin
                {
                    Id_medecin = reader.GetInt32(0),
                    Nom_medecin = reader.GetString(1),
                    Prenom_medecin = reader.GetString(2),
                    Tel_medecin = reader.GetString(3)
                });
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return listMedecin;
        }
    }
}
