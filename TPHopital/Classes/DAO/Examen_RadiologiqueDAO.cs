using System;
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
            createCmd = new SqlCommand("INSERT INTO "+TABLE+" (date_traitement, prix_traitement, designation, Resultat_examen, image, facture_id) values(@date, @prix, @designation, @resultat, @image, @facture_id )", connection);
            retrieveCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, designation, Resultat_examen, image, facture_id FROM " + TABLE + " where id_traitement like @search", connection);
            updateCmd = new SqlCommand("UPDATE " + TABLE + " SET date_traitement=@date, prix_traitement=@prix, designation=@designation, Resultat_examen=@resultat, image=@image, facture_id=@facture_id WHERE id_traitement=@id", connection);
            listAllCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, designation, Resultat_examen, image, facture_id FROM " + TABLE , connection);
        }

        public bool Create(Examen_Radiologique examen)
        {

           bool  created = false;
            createCmd.Parameters.Add(new SqlParameter("@date_traitement", examen.Date_traitement));
            createCmd.Parameters.Add(new SqlParameter("@prix", examen.Prix_traitement));
            createCmd.Parameters.Add(new SqlParameter("@designation", examen.Designation));
            createCmd.Parameters.Add(new SqlParameter("@Resultat_examen", examen.Resultat_examen));
            createCmd.Parameters.Add(new SqlParameter("@image", examen.Image));
            createCmd.Parameters.Add(new SqlParameter("@facture_id", examen.Facture_id));

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

        public bool Update(Examen_Radiologique examen, int id)
        {
            bool updated = false;
            updateCmd.Parameters.Clear();
            updateCmd.Parameters.Add(new SqlParameter("@date_traitement", examen.Date_traitement));
            updateCmd.Parameters.Add(new SqlParameter("@prix", examen.Prix_traitement));
            updateCmd.Parameters.Add(new SqlParameter("@designation", examen.Designation));
            updateCmd.Parameters.Add(new SqlParameter("@resultat", examen.Resultat_examen));
            updateCmd.Parameters.Add(new SqlParameter("@image", examen.Image));
            updateCmd.Parameters.Add(new SqlParameter("@facture_id", examen.Facture_id));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            if (updateCmd.ExecuteNonQuery() > 0)
                updated = true;
            updateCmd.Dispose();
            connection.Close();
            return updated;
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
                    Image = reader.GetString(5),
                    Facture_id = reader.GetInt32(6)
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
                examen = new Examen_Radiologique
                {
                    Id_traitement = reader.GetInt32(0),
                    Date_traitement = reader.GetDateTime(1),
                    Prix_traitement = reader.GetDecimal(2),
                    Designation = reader.GetString(3),
                    Resultat_examen = reader.GetString(4),
                    Image = reader.GetString(5),
                    Facture_id = reader.GetInt32(6)
                };
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return examen;
        }
    }
}
