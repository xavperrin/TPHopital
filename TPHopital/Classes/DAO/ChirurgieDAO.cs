using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.DAO
{
    class ChirurgieDAO : TraitementDAO, IDAO<ChirurgieDAO, Int32>
    {
        public void Create(ChirurgieDAO t)
        {
            throw new NotImplementedException();
        }

        public void Update(ChirurgieDAO t, int id)
        {
            throw new NotImplementedException();
        }

        List<ChirurgieDAO> IDAO<ChirurgieDAO, int>.ListAll()
        {
            throw new NotImplementedException();
        }

        ChirurgieDAO IDAO<ChirurgieDAO, int>.Retrieve(int id)
        {
            throw new NotImplementedException();
        }
    }
}
