using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TPHopital.Classes.DAO
{
    class PatientDAO : IDAO<Patient, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlConnection connection;
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
