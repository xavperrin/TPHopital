using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TPHopitalWpfEF.Classes.DAO
{
    public interface IDAO<T, ID>
    {
        bool Create(T t) ;
        T Retrieve(ID id);
        bool Update(T t, ID id);
        bool Delete(ID id);
        List<T> ListAll();
    }
}
