using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPHopital.Classes;
using TPHopital.Classes.Exceptions;
using TPHopital.Classes.DAO;

namespace UnitTestProject1
{
    [TestClass]
    public class TestMedecin
    {
        [TestMethod]
        public void TestNewMedecin()
        {
            string nom = "test nom";
            string prenom = "test prénom";
            string tel = "06test";
            Medecin m = new Medecin(nom, prenom, tel);

            Assert.AreEqual(nom, m.Nom_medecin);
            Assert.AreEqual(prenom, m.Prenom_medecin);
            Assert.AreEqual(tel, m.Tel_medecin);
            Assert.IsTrue(m.Id_medecin == 0);

        }

        [TestMethod]
        public void TestCreateMedecin()
        {
            Random random = new Random();
            int randomnumber=random.Next(90000000, 990000990);
            string nom = "nom"+ randomnumber;
            string prenom = "prénom"+ randomnumber;
            string tel = "0651155";
            Medecin m = new Medecin(nom, prenom, tel);

            MedecinDAO daomed = new MedecinDAO();
            bool inserted =daomed.Create(m);
            Assert.IsTrue(inserted);




        }
        [TestMethod]
        public void TestRetrieveMedecinByName()
        {
            string name = "nom801860743";

            MedecinDAO dao = new MedecinDAO();
            

            Medecin medecinretrieved = dao.Retrieve(name);

            

            Assert.IsNotNull(medecinretrieved);
            Assert.AreEqual(name, medecinretrieved.Nom_medecin);
            

        }


        


//


    }
}
