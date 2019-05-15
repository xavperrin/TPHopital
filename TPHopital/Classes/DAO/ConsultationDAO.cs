using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TPHopital.Classes.DAO
{
    public class ConsultationDAO : IDAO<Consultation, int>
    {

        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlConnection connection;

        public void Create(Consultation consultation)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Consultation Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Consultation consultation, int id)
        {
            throw new NotImplementedException();
        }
    }
}
