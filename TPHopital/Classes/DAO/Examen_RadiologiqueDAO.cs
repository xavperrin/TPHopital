﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TPHopital.Classes.Traitements;

namespace TPHopital.Classes.DAO
{
    class Examen_RadiologiqueDAO : TraitementDAO, IDAO<Examen_Radiologique, Int32>
    {
        public Examen_RadiologiqueDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Traitement (date_traitement, prix_traitement, designation, Resultat_examen, image) values(@date, @prix, @designation, @resultat, @image)", connection);
            retrieveCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, designation, Resultat_examen, image FROM Traitement where id_traitement like @search", connection);
            updateCmd = new SqlCommand("UPDATE Traitement SET date_traitement='@date', prix_traitement='@prix', designation='@designation', Resultat_examen='@resultat', image='@image' WHERE id=@id", connection);
            listAllCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, designation, Resultat_examen, image FROM Traitement", connection);
        }

        public void Create(Examen_Radiologique examen)
        {
            createCmd.Parameters.Add(new SqlParameter("@date_traitement", examen.Date_traitement));
            createCmd.Parameters.Add(new SqlParameter("@prix", examen.Prix_traitement));
            createCmd.Parameters.Add(new SqlParameter("@designation", examen.Designation));
            createCmd.Parameters.Add(new SqlParameter("@Resultat_examen", examen.Resultat_examen));
            createCmd.Parameters.Add(new SqlParameter("@image", examen.Image));

            connection.Open();

            if (createCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Insertion effecutée");
            }

            createCmd.Dispose();
            connection.Close();
        }

        public void Update(Examen_Radiologique examen, int id)
        {
            updateCmd.Parameters.Add(new SqlParameter("@date_traitement", examen.Date_traitement));
            updateCmd.Parameters.Add(new SqlParameter("@prix", examen.Prix_traitement));
            updateCmd.Parameters.Add(new SqlParameter("@designation", examen.Designation));
            updateCmd.Parameters.Add(new SqlParameter("@resultat", examen.Resultat_examen));
            updateCmd.Parameters.Add(new SqlParameter("@image", examen.Image));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));


            connection.Open();
            updateCmd.ExecuteNonQuery();
            updateCmd.Dispose();
            connection.Close();
        }

        public new List<Examen_Radiologique> ListAll()
        {
            List<Examen_Radiologique> listExamens = new List<Examen_Radiologique>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            while (reader.Read())
            {
                listExamens.Add(new Examen_Radiologique
                {
                    Id_traitement = reader.GetInt32(0),
                    Date_traitement = reader.GetDateTime(1),
                    Prix_traitement = reader.GetDecimal(2),
                    Designation = reader.GetString(3),
                    Resultat_examen = reader.GetString(4),
                    Image = reader.GetString(5)
                });
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return listExamens;
        }

        public new Examen_Radiologique Retrieve(int id)
        {
            Examen_Radiologique examen = null;

            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();


            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                examen = new Examen_Radiologique();
                examen.Id_traitement = reader.GetInt32(0);
                examen.Date_traitement = reader.GetDateTime(1);
                examen.Prix_traitement = reader.GetDecimal(2);
                examen.Designation = reader.GetString(3);
                examen.Resultat_examen = reader.GetString(4);
                examen.Image = reader.GetString(5);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return examen;
        }
    }
}
