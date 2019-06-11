using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using TPHopital.Classes.Exceptions;


namespace TPHopital.Classes.DAO
{
    public class MedecinDAO : IDAO<Medecin, int>
    {
        private static readonly string sname = typeof(MedecinDAO).Name;
        private SqlCommand createCmd;
        private SqlCommand retrievebynameCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlCommand listAllCmd;
        private SqlConnection connection;

        private readonly string TABLE = "Medecin";
        private readonly string COLUMNS = "nom_medecin, prenom_medecin, tel_medecin";
        private string createTxt;
        private readonly string retrieveTxt;
        private readonly string updateTxt;
        private readonly string deleteTxt;
        private readonly string retrieveByNameTxt;
        private readonly string listAllTxt;

        public MedecinDAO() 
        {
            connection = Connection.Instance;

            
            retrieveTxt = "SELECT id_medecin, " + COLUMNS + " FROM " + TABLE + " where id_medecin like @search";
            updateTxt = "UPDATE " + TABLE + " SET nom_medecin=@nom, prenom_medecin=@prenom, tel_medecin=@tel WHERE id_medecin=@id";
            deleteTxt = "DELETE FROM " + TABLE + " WHERE id_medecin=@id ";

            retrieveByNameTxt = "SELECT id_medecin, " + COLUMNS + " FROM Medecin where nom_medecin like @searchname";
            listAllTxt= "SELECT " + COLUMNS + " FROM " + TABLE;

        }

        public bool Create(Medecin medecin)
        {
            bool created = false;
            if (medecin == null)
                throw new ArgumentNullException(nameof(medecin));
            createCmd = null;

            try
            {
                
                
                if (medecin.Id_medecin != 0)
                {
                    
                    createTxt = "INSERT INTO id_medecin, " + TABLE + " (" + COLUMNS + ") values(@id, @nom, @prenom, @tel)";

                    createCmd = new SqlCommand(createTxt, connection);
                    createCmd.Parameters.Clear();
                    createCmd.Parameters.Add(new SqlParameter("@id", medecin.Id_medecin));

                }
                else
                {
                    createTxt = "INSERT INTO " + TABLE + " (" + COLUMNS + ") values(@nom, @prenom, @tel)";
                    createCmd = new SqlCommand(createTxt, connection);
                    createCmd.Parameters.Clear();
                    
                }
                
                createCmd.Parameters.Add(new SqlParameter("@nom", medecin.Nom_medecin));
                createCmd.Parameters.Add(new SqlParameter("@prenom", medecin.Prenom_medecin));
                createCmd.Parameters.Add(new SqlParameter("@tel", medecin.Tel_medecin));
                connection.Open();

                if (createCmd.ExecuteNonQuery() > 0)
                {
                    created = true;
                }
            }
            catch (SqlException ex)
            {
                DisplaySqlException(ex);
                throw new DataAccessException("Cannot insert data into the database", ex);
            }
            finally
            {

                
                if (createCmd != null) createCmd.Dispose();
                if (connection != null) connection.Close();
          
               
            }
            return created;
        }

        public int GetUniqueId()
        {
            Random random = new Random();
            return random.Next(1000, 90000);
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            deleteCmd = null;
            deleteCmd = new SqlCommand(deleteTxt,connection);
            deleteCmd.Parameters.Clear();
            deleteCmd.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            if (deleteCmd.ExecuteNonQuery() == 0)
            {
                throw new MedecinNotFoundException("Aucun medecin n'a été trouvé avec l'identifiant " + id + ". Il ne peut etre supprime.");
                
            }
            else
            {
                Console.WriteLine("Suppression effecutée");
                deleted = true;
            }
               

            deleteCmd.Dispose();
            connection.Close();
            return deleted;
        }

        public Medecin Retrieve(int id)
        {
            Medecin medecin = null;
            
            SqlDataReader reader = null;
            retrieveCmd = null;

            try
            {
                retrieveCmd = new SqlCommand(retrieveTxt, connection);

                retrieveCmd.Parameters.Clear();

                retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

                connection.Open();

                reader = retrieveCmd.ExecuteReader();

                if (!reader.Read())
                {
                    throw new MedecinNotFoundException("Aucun medecin n'a été trouvé avec l'identifiant " + id);
                }
                else
                    medecin = new Medecin
                    {
                        Id_medecin = reader.GetInt32(0),
                        Nom_medecin = reader.GetString(1),
                        Prenom_medecin = reader.GetString(2),
                        Tel_medecin = reader.GetString(3)
                    };
                
            }
            catch (SqlException e)
            {
                // A Severe SQL Exception is caught
                DisplaySqlException(e);
                throw new DataAccessException("Cannot get data from the database: "+ e.Message, e);
            }
            finally
            {
                try
                {
                    if (reader != null) reader.Close();
                    if (retrieveCmd != null) retrieveCmd.Dispose();
                    if (connection != null) connection.Close();
                }
                catch (SqlException e)
                {
                    DisplaySqlException("Cannot close connection", e);
                    throw new DataAccessException("Cannot close the database connection", e);
                }
            }
            return medecin;
        }

        

        public Medecin Retrieve(string name)
        {
            Medecin medecin = null;
            retrievebynameCmd = null;
            SqlDataReader reader = null;

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            try
            {
                retrievebynameCmd = new SqlCommand(retrieveByNameTxt, connection);
                retrievebynameCmd.Parameters.Clear();
                retrievebynameCmd.Parameters.Add(new SqlParameter("@searchname", name));

                connection.Open();

                reader = retrievebynameCmd.ExecuteReader();

                if (!reader.Read())
                {
                    throw new MedecinNotFoundException("Aucun medecin n'a été trouvé avec le nom " + name);
                }
                else
                {
                    medecin = new Medecin
                    {

                        Id_medecin = reader.GetInt32(0),
                        Nom_medecin = reader.GetString(1),
                        Prenom_medecin = reader.GetString(2),
                        Tel_medecin = reader.GetString(3)
                    };
                }
            }
            catch (SqlException e)
            {
                // A Severe SQL Exception is caught
                DisplaySqlException(e);
                throw new DataAccessException("Cannot get data from the database: " + e.Message, e);
            }
            finally
            //Close
            {
                try
                {
                    if (reader != null) reader.Close();
                    if (retrievebynameCmd != null) retrievebynameCmd.Dispose();
                    if (connection != null) connection.Close();
                }
                catch (SqlException ex)
                {
                    DisplaySqlException("Cannot close connection", ex);
                    throw new DataAccessException("Cannot close the database connection", ex);
                }
            }
            return medecin;
        }

        public bool Update(Medecin medecin, int id)
        {
            bool updated = false;
            updateCmd = null;
            if (medecin==null)
                throw new ArgumentNullException(nameof(medecin));
            try
            {
                updateCmd = new SqlCommand(updateTxt, connection);
                updateCmd.Parameters.Clear();
                updateCmd.Parameters.Add(new SqlParameter("@nom", medecin.Nom_medecin));
                updateCmd.Parameters.Add(new SqlParameter("@prenom", medecin.Prenom_medecin));
                updateCmd.Parameters.Add(new SqlParameter("@tel", medecin.Tel_medecin));

                updateCmd.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();

                if (updateCmd.ExecuteNonQuery() <= 0)
                    throw new ObjectNotFoundException("Aucun medecin n'a été trouvé avec l'identifiant " + id + ". Il ne peut pas etre mis à jour.");
                else
                    updated = true;
            }
            catch (SqlException ex)
            {

                // A Severe SQL Exception is caught
                DisplaySqlException(ex);
                throw new DataAccessException("Cannot update data into the database", ex);
            }
            finally
            {
                //Close
                try
                {
                    if (updateCmd != null) createCmd.Dispose();
                    if (connection != null) connection.Close();
                }
                catch (SqlException e)
                {

                    DisplaySqlException("Cannot close connection", e);
                    throw new DataAccessException("Cannot close the database connection", e);
                }
            }
            return updated;
        }

        public List<Medecin> ListAll()
        {
            listAllCmd = null;
            SqlDataReader reader = null;
            List<Medecin> listMedecins = new List<Medecin>();

            try
            {
                listAllCmd = new SqlCommand(listAllTxt, connection);
                connection.Open();

                reader = listAllCmd.ExecuteReader();

                while (reader.Read())
                {
                    listMedecins.Add(new Medecin
                    {
                        Id_medecin = reader.GetInt32(0),
                        Nom_medecin = reader.GetString(1),
                        Prenom_medecin = reader.GetString(2),
                        Tel_medecin = reader.GetString(3)
                    });
                }

                if (listMedecins != null && listMedecins.Count == 0)
                    throw new ObjectNotFoundException();
            }

            catch (SqlException e)
            {

                DisplaySqlException(e);
                throw new DataAccessException("Cannot get data from the database: " + e.Message, e);
            }
            finally
            {
                //Close
                try
                {
                    if (reader != null) reader.Close();
                    if (listAllCmd != null) retrieveCmd.Dispose();
                    if (connection != null) connection.Close();
                }
                catch (SqlException e)
                {
                    DisplaySqlException("Cannot close connection", e);
                    throw new DataAccessException("Cannot close the database connection", e);
                }
            }
            return listMedecins;
        }

        private void DisplaySqlException(String message, SqlException e)
        {
            const String mname = "DisplaySqlException";
            Trace.TraceWarning(sname, mname, "Message     : " + message);
            Trace.TraceWarning(sname, mname, "Error code  : " + e.ErrorCode);
            Trace.TraceWarning(sname, mname, "SQL state   : " + e.State);
            Trace.TraceWarning(sname, mname, "SQL message : " + e.Message);
            Trace.TraceError(sname, mname, e);
        }


        private void DisplaySqlException(SqlException e)
        {
            const string mname = "displaySqlException";

            Trace.TraceError(sname, mname, "Error code  : " + e.ErrorCode);

            Trace.TraceError(sname, mname, "SQL state   : " + e.State);
            Trace.TraceError(sname, mname, "SQL message : " + e.Message);

        }
    }
}
