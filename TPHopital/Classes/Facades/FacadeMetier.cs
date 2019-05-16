using System;
using System.Collections.Generic;
using System.Text;
using TPHopital.Classes.DAO;
using TPHopital.Classes.DTOs;
using TPHopital.Classes.Traitements;

namespace TPHopital.Classes.Facades
{
    
    public class FacadeMetier
    {
        static public IDAO<Medecin, int> medecindao;
        static public IDAO<Consultation, int> consultationdao;
        static public IDAO<Examen_Biologique, int> examenbiologiquedao;
        static public IDAO<Examen_Radiologique, int> examenradiologiquedao;
        static public IDAO<Facture, int> facturedao;
        static public IDAO<Hospitalisation, int> hospitalisationdao;

        public FacadeMetier()
        {

            medecindao = new MedecinDAO();


        }

       

        static public void Add(Medecin m)
        {
            medecindao.Create(m);
        }

        static public void Add(Consultation c)
        {
            consultationdao.Create(c);
        }

        static public void Add(Examen_Biologique e)
        {
            examenbiologiquedao.Create(e);
        }

        static public void Add(Facture f)
        {
            facturedao.Create(f);
        }

        static public void Add(Hospitalisation h)
        {
            hospitalisationdao.Create(h);
        }
    }
}
