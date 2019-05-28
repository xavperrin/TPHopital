using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TPHopital.Classes.Traitements;

namespace TPHopital.Classes.DAO
{
    class ChirurgieDAO : TraitementDAO, IDAO<Chirurgie, int>
    {
        public ChirurgieDAO()
        {
            connection = Connection.Instance;
            createCmd = new SqlCommand("INSERT INTO Traitement (date_traitement, prix_traitement, chirurgien, anesthesiste, facture_id) values(@date, @prix, @chirurgien, @anesthesiste)", connection);
            retrieveCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, chirurgien, anesthesiste, facture_id FROM Traitement where id_traitement like @search", connection);
            updateCmd = new SqlCommand("UPDATE Traitement SET date_traitement=@date, prix_traitement=@prix, chirurgien=@chirurgien, anesthesiste=@anesthesiste, facture_id=@facture_id WHERE id_traitement=@id", connection);
            listAllCmd = new SqlCommand("SELECT id_traitement, date_traitement, prix_traitement, chirurgien, anesthesiste, facture_id FROM Traitement", connection);
        }

        public void Create(Chirurgie chirurgie)
        {
            Task t = Task.Run(() =>
            {
                createCmd.Parameters.Add(new SqlParameter("@date_traitement", chirurgie.Date_traitement));
                createCmd.Parameters.Add(new SqlParameter("@prix", chirurgie.Prix_traitement));
                createCmd.Parameters.Add(new SqlParameter("@chirurgien", chirurgie.Chirurgien));
                createCmd.Parameters.Add(new SqlParameter("@anesthesiste", chirurgie.Anesthesiste));
                createCmd.Parameters.Add(new SqlParameter("@facture_id", chirurgie.Facture_id));

                lock (new object())
                {
                    connection.Open();

                    if (createCmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Insertion effecutée");
                    }

                    createCmd.Dispose();
                    connection.Close();
                }
            });
            t.Wait();
        }

        public void Update(Chirurgie chirurgie, int id)
        {
            Task.Run(() =>
            {
                updateCmd.Parameters.Add(new SqlParameter("@date_traitement", chirurgie.Date_traitement));
                updateCmd.Parameters.Add(new SqlParameter("@prix", chirurgie.Prix_traitement));
                updateCmd.Parameters.Add(new SqlParameter("@chirurgien", chirurgie.Chirurgien));
                updateCmd.Parameters.Add(new SqlParameter("@anesthesiste", chirurgie.Anesthesiste));
                updateCmd.Parameters.Add(new SqlParameter("@facture_id", chirurgie.Facture_id));

                updateCmd.Parameters.Add(new SqlParameter("@id", id));

                lock (new object())
                {
                    connection.Open();
                    updateCmd.ExecuteNonQuery();
                    updateCmd.Dispose();
                    connection.Close();
                }
            });
        }

        public new List<Chirurgie> ListAll()
        {
            Task<List<Chirurgie>> t = Task.Run(new Func<List<Chirurgie>>(() =>
            {
                List<Chirurgie> listChirurgies = new List<Chirurgie>();
                SqlDataReader reader = listAllCmd.ExecuteReader();

                lock (new object())
                {
                    connection.Open();

                    while (reader.Read())
                    {
                        listChirurgies.Add(new Chirurgie
                        {
                            Id_traitement = reader.GetInt32(0),
                            Date_traitement = reader.GetDateTime(1),
                            Prix_traitement = reader.GetDecimal(2),
                            Chirurgien = reader.GetString(3),
                            Anesthesiste = reader.GetString(4),
                            Facture_id = reader.GetInt32(5)
                        });
                    }

                    reader.Close();
                    retrieveCmd.Dispose();
                    connection.Close();
                    return listChirurgies;
                }
            }));

            return t.Result;
        }

        public new Chirurgie Retrieve(int id)
        {
            Task<Chirurgie> t = Task.Run(() =>
            {
                Chirurgie chirurgie = null;

                retrieveCmd.Parameters.Add(new SqlParameter("@search", id));

                lock (new object())
                {
                    connection.Open();

                    SqlDataReader reader = retrieveCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        chirurgie = new Chirurgie();
                        chirurgie.Id_traitement = reader.GetInt32(0);
                        chirurgie.Date_traitement = reader.GetDateTime(1);
                        chirurgie.Prix_traitement = reader.GetDecimal(2);
                        chirurgie.Chirurgien = reader.GetString(3);
                        chirurgie.Anesthesiste = reader.GetString(4);
                        chirurgie.Facture_id = reader.GetInt32(5);
                    }

                    reader.Close();
                    retrieveCmd.Dispose();
                    connection.Close();

                    return chirurgie;
                }
            });

            return t.Result;
        }
    }
}
