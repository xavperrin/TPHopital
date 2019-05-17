using System;
using System.Collections.Generic;
using System.Text;
using TPHopital.Classes.DAO;
using TPHopital.Classes.DTOs;
using TPHopital.Classes.Traitements;

namespace TPHopital.Classes.Facades
{
    
    public static class FacadeMetier
    {
        static public IDAO<Medecin, int> medecindao;
        static public IDAO<Consultation, int> consultationdao;
        static public IDAO<Examen_Biologique, int> examenbiologiquedao;
        static public IDAO<Examen_Radiologique, int> examenradiologiquedao;
        static public IDAO<Facture, int> facturedao;
        static public IDAO<Hospitalisation, int> hospitalisationdao;

        public static void Init()
        {

            medecindao = new MedecinDAO();
            consultationdao = new ConsultationDAO();
            examenbiologiquedao = new Examen_BiologiqueDAO();
            examenradiologiquedao = new Examen_RadiologiqueDAO();
            facturedao = new FactureDAO();
            hospitalisationdao = new HospitalisationDAO();

        }

       
        // Generate a random number between two numbers
public static int RandomNumber()
        {
            Random random = new Random();
            return random.Next();
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


        static public void Delete(Medecin m)
        {
            medecindao.Delete(m.Id_medecin);
        }

        static public void Delete(Consultation c)
        {
            consultationdao.Delete(c.Id_consultation);
        }

        static public void Delete(Examen_Biologique e)
        {
            examenbiologiquedao.Delete(e.Facture_id);
        }

        static public void Delete(Facture f)
        {
            facturedao.Delete(f.Id_facture);
        }

        static public void Delete(Hospitalisation h)
        {
            hospitalisationdao.Delete(h.Id_admission);
        }


        static public void DeleteMedecin(int idmedecin)
        {
            medecindao.Delete(idmedecin);
        }

        static public void DeleteConsultation (int idconsultation)
        {
            consultationdao.Delete(idconsultation);
        }

        static public void DeleteExamen_Biologique(int idexamen)
        {
            examenbiologiquedao.Delete(idexamen);
        }

        static public void DeleteFacture(int idfacture)
        {
            facturedao.Delete(idfacture);
        }

        static public void DeleteHospitalisation(int idhospistalisation)
        {
            hospitalisationdao.Delete(idhospistalisation);
        }
    }
}
