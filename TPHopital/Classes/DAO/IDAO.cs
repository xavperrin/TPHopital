using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.DAO
{
    interface IDAO<T, ID>
    {
        void Create(T t);
        T Retrieve(ID id);
        void Update(T t, ID id);
        void Delete(ID id);
    }
}
