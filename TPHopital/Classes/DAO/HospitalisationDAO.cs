using System;
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

        private readonly string COLUMNS="date_admission, type_admission, motif_admission, medecin_traitant, nom_accompagnant," +
            " prenom_accompagnant, lien_parente, date_entreeAcc, date_sortieAcc, motif_sortie, resultat_sortie, date_deces," +
            " motif_deces, patient_id, traitement_id";
        private readonly string TABLE="Hospitalisation";



        public HospitalisationDAO()
        {
           connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO "+TABLE+" ("+COLUMNS+") values(@date_admission, @type_admission, @motif_admission," +
                " @medecin_traitant, @nom_accompagnant, @prenom_accompagnant, @lien_parente, @date_entreeAcc, @date_sortieAcc, @motif_sortie," +
                " @resultat_sortie, @date_deces, @motif_deces, @patient_id, @traitement_id)", connection);
            retrieveCmd = new SqlCommand("SELECT id_admission "+ COLUMNS + " FROM "+ TABLE + " where id_admission like @search", connection);
            updateCmd = new SqlCommand("UPDATE " + TABLE + " SET date_admission='@date_admission', type_admission='@type_admission', motif_admission='@motif_admission'," +
                " medecin_traitant='@medecin_traitant', nom_accompagnant='@nom_accompagnant', prenom_accompagnant='@prenom_accompagnant', lien_parente='@lien_parente'," +
                " date_entreeAcc='@date_entreeAcc', date_sortieAcc='@date_sortieAcc', motif_sortie='@motif_sortie'," +
                " resultat_sortie='@resultat_sortie', date_deces='@date_deces'", connection);
            deleteCmd = new SqlCommand("DELETE FROM " + TABLE + " WHERE id_admission=@id ", connection);
            listAllCmd = new SqlCommand("SELECT id_admission " + COLUMNS + " FROM " + TABLE , connection);
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
            throw new NotImplementedException();
        }

        public Hospitalisation Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Hospitalisation hospitalisation, int id)
        {
            throw new NotImplementedException();
        }

        public List<Hospitalisation> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
