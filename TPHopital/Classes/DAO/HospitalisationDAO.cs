﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TPHopital.Classes.DAO
{
    class HospitalisationDAO : IDAO<Hospitalisation, Int32>
    {
        private SqlCommand createCmd;
        private SqlCommand retrieveCmd;
        private SqlCommand updateCmd;
        private SqlCommand deleteCmd;
        private SqlConnection connection;
        public void Create(Hospitalisation hospitalisation)
        {
            throw new NotImplementedException();
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
    }
}
