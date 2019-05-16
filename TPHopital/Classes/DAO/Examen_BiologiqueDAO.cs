using System;
using System.Collections.Generic;
using System.Text;
using TPHopital.Classes.Traitements;

namespace TPHopital.Classes.DAO
{
    class Examen_BiologiqueDAO : TraitementDAO, IDAO<Examen_Biologique, Int32>
    {
        public Examen_BiologiqueDAO()
        {
        }

        public void Create(Examen_Biologique t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Examen_Biologique> ListAll()
        {
            throw new NotImplementedException();
        }

        public Examen_Biologique Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Examen_Biologique t, int id)
        {
            throw new NotImplementedException();
        }
    }
}
