using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using TPHopitalWpfEF.Classes.Traitements;

namespace TPHopitalWpfEF.Classes.DAO
{
    class Examen_BiologiqueDAO : TraitementDAO, IDAO<Examen_Biologique, Int32>
    {

        public Examen_BiologiqueDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Traitement (date_traitement, prix_traitement, designation, Resultat_examen, Facture_id) values(@date, @prix, @designation, @resultat)", connection);
            retrieveCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, designation, Resultat_examen, Facture_id FROM Traitement where id_traitement like @search", connection);
            updateCmd = new SqlCommand("UPDATE Traitement SET date_traitement=@date, prix_traitement=@prix, designation=@designation, Resultat_examen=@resultat, Facture_id=@facture_id WHERE id_traitement=@id", connection);
            listAllCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, designation, Resultat_examen, Facture_id FROM Traitement", connection);
        }

        public bool Create(Examen_Biologique examen)
        {
            bool created = false;
            createCmd.Parameters.Clear();
            createCmd.Parameters.Add(new SqlParameter("@date_traitement", examen.Date_traitement));
            createCmd.Parameters.Add(new SqlParameter("@prix", examen.Prix_traitement));
            createCmd.Parameters.Add(new SqlParameter("@designation", examen.Designation));
            createCmd.Parameters.Add(new SqlParameter("@Resultat_examen", examen.Resultat_examen));
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

        public new List<Examen_Biologique> ListAll()
        {
            List<Examen_Biologique> listExamens = new List<Examen_Biologique>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            while (reader.Read())
            {
                listExamens.Add(new Examen_Biologique
                {
                    Id_traitement = reader.GetInt32(0),
                    Date_traitement = reader.GetDateTime(1),
                    Prix_traitement = reader.GetDecimal(2),
                    Designation = reader.GetString(3),
                    Resultat_examen = reader.GetString(4),
                    Facture_id=reader.GetInt32(5)
            });
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return listExamens;
        }

        public new Examen_Biologique Retrieve(int id)
        {
            Examen_Biologique examen = null;
            retrieveCmd.Parameters.Clear();
            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();

            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                examen = new Examen_Biologique();
                examen.Id_traitement = reader.GetInt32(0);
                examen.Date_traitement = reader.GetDateTime(1);
                examen.Prix_traitement = reader.GetDecimal(2);
                examen.Designation = reader.GetString(3);
                examen.Resultat_examen = reader.GetString(4);
                examen.Facture_id = reader.GetInt32(5);
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return examen;
        }

        public bool Update(Examen_Biologique examen, int id)
        {
            bool updated = false;
            updateCmd.Parameters.Clear();
            updateCmd.Parameters.Add(new SqlParameter("@date_traitement", examen.Date_traitement));
            updateCmd.Parameters.Add(new SqlParameter("@prix", examen.Prix_traitement));
            updateCmd.Parameters.Add(new SqlParameter("@designation", examen.Designation));
            updateCmd.Parameters.Add(new SqlParameter("@resultat", examen.Resultat_examen));
            updateCmd.Parameters.Add(new SqlParameter("@facture_id", examen.Facture_id ));
            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            if (updateCmd.ExecuteNonQuery()>0)
                updated = true;
            updateCmd.Dispose();
            connection.Close();
            return updated;
        }

       
    }
}
