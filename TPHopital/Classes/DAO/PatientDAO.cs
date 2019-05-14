using System;
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
            createCmd = new SqlCommand("INSERT INTO Client (nom,prenom) values(@nom,@prenom)", connection);
            retrieveCmd = new SqlCommand("SELECT * FROM Client where nom like @search OR prenom like @search", connection);
            updateCmd = new SqlCommand("UPDATE client SET nom='@nom', prenom='@prenom', tel='@tel' WHERE id=@id");
            deleteCmd = new SqlCommand("DELETE FROM client WHERE id=@id ");
        }

        public void Create(Patient patient)
        {
            throw new NotImplementedException();
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
