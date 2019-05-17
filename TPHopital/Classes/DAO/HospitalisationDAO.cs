﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TPHopital.Classes.DAO
{
    public class HospitalisationDAO : IDAO<Hospitalisation, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;

        private readonly string COLUMNS = "date_admission, type_admission, motif_admission, medecin_traitant, nom_accompagnant," +
            " prenom_accompagnant, lien_parente, date_entreeAcc, date_sortieAcc, date_sortie, motif_sortie, resultat_sortie, date_deces," +
            " motif_deces, patient_id, traitement_id";
        private readonly string TABLE = "Hospitalisation";

        public HospitalisationDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO " + TABLE + " (" + COLUMNS + ") values(@date_admission, @type_admission, @motif_admission," +
                " @medecin_traitant, @nom_accompagnant, @prenom_accompagnant, @lien_parente, @date_entreeAcc, @date_sortieAcc, @motif_sortie," +
                " @resultat_sortie, @date_deces, @motif_deces, @patient_id, @traitement_id)", connection);
            retrieveCmd = new SqlCommand("SELECT id_admission, " + COLUMNS + " FROM " + TABLE + " where id_admission like @search", connection);
            updateCmd = new SqlCommand("UPDATE " + TABLE + " SET date_admission='@date_admission', type_admission='@type_admission', motif_admission='@motif_admission'," +
                " medecin_traitant='@medecin_traitant', nom_accompagnant='@nom_accompagnant', prenom_accompagnant='@prenom_accompagnant', lien_parente='@lien_parente'," +
                " date_entreeAcc='@date_entreeAcc', date_sortieAcc='@date_sortieAcc', motif_sortie='@motif_sortie'," +
                " resultat_sortie='@resultat_sortie', date_deces='@date_deces'", connection);
            deleteCmd = new SqlCommand("DELETE FROM " + TABLE + " WHERE id_admission=@id ", connection);
            listAllCmd = new SqlCommand("SELECT id_admission " + COLUMNS + " FROM " + TABLE, connection);
        }
        public void Create(Hospitalisation hospitalisation)
        {
            createCmd.Parameters.Add(new SqlParameter("@date_admission", hospitalisation.Date_admission));
            createCmd.Parameters.Add(new SqlParameter("@type_admission", hospitalisation.Type_admission));
            createCmd.Parameters.Add(new SqlParameter("@motif_admission", hospitalisation.Motif_admission));
            createCmd.Parameters.Add(new SqlParameter("@medecin_traitant", hospitalisation.Medecin_traitant));

            createCmd.Parameters.Add(new SqlParameter("@nom_accompagnant", hospitalisation.Nom_accompagnant));
            createCmd.Parameters.Add(new SqlParameter("@prenom_accompagnant", hospitalisation.Prenom_accompagnant));
            createCmd.Parameters.Add(new SqlParameter("@lien_parente", hospitalisation.Lien_parente));

            createCmd.Parameters.Add(new SqlParameter("@date_entreeAcc", hospitalisation.Date_entreeAcc));
            //
            //SORTIE
            //
            createCmd.Parameters.Add(new SqlParameter("@date_sortieAcc", hospitalisation.Date_sortieAcc));
            createCmd.Parameters.Add(new SqlParameter("@motif_sortie", hospitalisation.Motif_sortie));
            createCmd.Parameters.Add(new SqlParameter("@resultat_sortie", hospitalisation.Resultat_sortie));
            //
            // DECES
            //
            createCmd.Parameters.Add(new SqlParameter("@date_deces", hospitalisation.Date_deces));
            createCmd.Parameters.Add(new SqlParameter("@motif_deces", hospitalisation.Motif_deces));
            createCmd.Parameters.Add(new SqlParameter("@patient_id", hospitalisation.Patient_id));
            createCmd.Parameters.Add(new SqlParameter("@traitement_id", hospitalisation.Traitement_id));


            connection.Open();

            if (createCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Insertion effecutée");
            }
            else throw new HospitalisationCreateException("Cette hospitalisation n'a pas pu etre créée dans la base de données.");

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
                throw new ObjectNotFoundException("Aucune hospitalisation n'a été trouvée avec l'identifiant " + id + ". Elle ne peut etre supprimee.");

            deleteCmd.Dispose();
            connection.Close();
        }

        public Hospitalisation Retrieve(int id)
        {
            Hospitalisation hospitalisation = null;

            retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

            connection.Open();

            SqlDataReader reader = retrieveCmd.ExecuteReader();

            if (reader.Read())
            {
                hospitalisation = new Hospitalisation();
                hospitalisation.Id_admission = reader.GetInt32(0);
                hospitalisation.Date_admission = reader.GetDateTime(1);
                hospitalisation.Type_admission = reader.GetString(2);
                hospitalisation.Motif_admission = reader.GetString(3);
                hospitalisation.Medecin_traitant = reader.GetString(4);
                hospitalisation.Nom_accompagnant = reader.GetString(5);
                hospitalisation.Prenom_accompagnant = reader.GetString(6);
                hospitalisation.Lien_parente = reader.GetString(7);
                hospitalisation.Date_entreeAcc = reader.GetDateTime(8);
                hospitalisation.Date_sortieAcc = reader.GetDateTime(9);
                hospitalisation.Date_sortie = reader.GetDateTime(10);
                hospitalisation.Motif_sortie = reader.GetString(11);
                hospitalisation.Resultat_sortie = reader.GetString(12);
                hospitalisation.Date_deces = reader.GetDateTime(13);
                hospitalisation.Motif_deces = reader.GetString(14);
                hospitalisation.Patient_id = reader.GetInt32(15);
                hospitalisation.Traitement_id = reader.GetInt32(16);

            }
            else
                throw new ObjectNotFoundException("Aucun hospitalisation n'a été trouvé avec l'identifiant " + id);

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return hospitalisation;
        }

        public void Update(Hospitalisation hospitalisation, int id)
        {
            updateCmd.Parameters.Add(new SqlParameter("@date_admission", hospitalisation.Date_admission));
            updateCmd.Parameters.Add(new SqlParameter("@type_admission", hospitalisation.Type_admission));
            updateCmd.Parameters.Add(new SqlParameter("@motif_admission", hospitalisation.Motif_admission));
            updateCmd.Parameters.Add(new SqlParameter("@medecin_traitant", hospitalisation.Medecin_traitant));

            updateCmd.Parameters.Add(new SqlParameter("@nom_accompagnant", hospitalisation.Nom_accompagnant));
            updateCmd.Parameters.Add(new SqlParameter("@prenom_accompagnant", hospitalisation.Prenom_accompagnant));
            updateCmd.Parameters.Add(new SqlParameter("@lien_parente", hospitalisation.Lien_parente));

            updateCmd.Parameters.Add(new SqlParameter("@date_entreeAcc", hospitalisation.Date_entreeAcc));
            //
            //SORTIE
            //
            updateCmd.Parameters.Add(new SqlParameter("@date_sortieAcc", hospitalisation.Date_sortieAcc));
            updateCmd.Parameters.Add(new SqlParameter("@motif_sortie", hospitalisation.Motif_sortie));
            updateCmd.Parameters.Add(new SqlParameter("@resultat_sortie", hospitalisation.Resultat_sortie));
            //
            // DECES
            //
            updateCmd.Parameters.Add(new SqlParameter("@date_deces", hospitalisation.Date_deces));
            updateCmd.Parameters.Add(new SqlParameter("@motif_deces", hospitalisation.Motif_deces));
            updateCmd.Parameters.Add(new SqlParameter("@patient_id", hospitalisation.Patient_id));
            updateCmd.Parameters.Add(new SqlParameter("@traitement_id", hospitalisation.Traitement_id));

            updateCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            if (updateCmd.ExecuteNonQuery() <= 0)
                throw new ObjectNotFoundException("Aucune hospitalisation n'a été trouvée avec l'identifiant " + id + ". Elle ne peut pas etre mise à jour.");



            updateCmd.Dispose();
            connection.Close();
        }

        public List<Hospitalisation> ListAll()
        {
            List<Hospitalisation> listHospitalisations = new List<Hospitalisation>();

            connection.Open();

            SqlDataReader reader = listAllCmd.ExecuteReader();

            while (reader.Read())
            {
                listHospitalisations.Add(new Hospitalisation
                {
                    Id_admission = reader.GetInt32(0),
                    Date_admission = reader.GetDateTime(1),
                    Type_admission = reader.GetString(2),
                    Motif_admission = reader.GetString(3),
                    Medecin_traitant = reader.GetString(4),
                    Nom_accompagnant = reader.GetString(5),
                    Prenom_accompagnant = reader.GetString(6),
                    Lien_parente = reader.GetString(7),
                    Date_entreeAcc = reader.GetDateTime(8),
                    Date_sortieAcc = reader.GetDateTime(9),
                    Date_sortie = reader.GetDateTime(10),
                    Motif_sortie = reader.GetString(11),
                    Resultat_sortie = reader.GetString(12),
                    Date_deces = reader.GetDateTime(13),
                    Motif_deces = reader.GetString(14),
                    Patient_id = reader.GetInt32(15),
                    Traitement_id = reader.GetInt32(16)
                });
            }

            reader.Close();
            retrieveCmd.Dispose();
            connection.Close();

            return listHospitalisations;
        }
    }
}
