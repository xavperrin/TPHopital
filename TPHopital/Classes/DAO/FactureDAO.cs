using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TPHopital.Classes.DAO
{
    public class FactureDAO : IDAO<Facture, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlConnection connection;
        public void Create(Facture facture)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Facture Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Facture facture, int id)
        {
            throw new NotImplementedException();
        }
    }
}
