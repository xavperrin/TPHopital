using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPHopital.Classes;
using TPHopital.Classes.Exceptions;
using TPHopital.Classes.DAO;
using System.Data.SqlClient;

namespace UnitTestProject1
{
    [TestClass]
    public class TestMedecin
    {
        private MedecinDAO _dao = new MedecinDAO();
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
        public void TestCreateMedecin2()
        {
            Random random = new Random();
            int randomnumber = random.Next(90000000, 990000990);
            string nom = "nom" + randomnumber;
            string prenom = "prénom" + randomnumber;
            string tel = "0651122";
            Medecin m = new Medecin(nom, prenom, tel);


            bool inserted = _dao.Create(m);
            Assert.IsTrue(inserted);




        }
        [TestMethod]
        public void TestRetrieveMedecinByName()
        {
            string name = "nom534090028";

            MedecinDAO dao = new MedecinDAO();


            Medecin medecinretrieved = dao.Retrieve(name);


            Assert.IsNotNull(medecinretrieved);
            Assert.AreEqual(name, medecinretrieved.Nom_medecin);
        }

        [TestMethod]
        public void TestRetrieveMedecinWithInvalidValues()
        {

            // Finds an medecin with a unknown identifier
            int id = _dao.GetUniqueId();
            string message;
            try
            {
                FindMedecin(id);
                message = String.Format("Object with unknonw id should not be found", id);
                Assert.Fail(message);

            }
            catch (MedecinNotFoundException e)
            {
            }

            // Finds an object with an empty identifier
            try
            {
                _dao.Retrieve(String.Empty);
                message = String.Format("Object with empty id should not be found");
                Assert.Fail(message);

            }
            catch (MedecinNotFoundException e)
            {
            }

            // Finds an object with a null identifier
            try
            {
                _dao.Retrieve(null);
                Assert.Fail("Medecin with null id should not be found");
            }
            catch (ArgumentNullException e)
            {
            }
        }
        /**
     * This test ensures that the method findAll medecins. It does a first findAll, creates
     * a new object and does a second findAll.
     */
        [TestMethod]
        public void TestFindAllCategories()
        {
            int id = _dao.GetUniqueId();

            // First findAll
            int firstSize = FindAllMedecins();

            // Creates an object
            CreateMedecin(id);

            // Ensures that the object exists
            try
            {
                FindMedecin(id);
            }
            catch (ObjectNotFoundException e)
            {
                Assert.Fail("Object has been created it should be found");
            }

            // Second findAll
            int secondSize = FindAllMedecins();

            // Checks that the collection size has increase of one
            if (firstSize + 1 != secondSize) Assert.Fail("The collection size should have increased by 1");

            // Cleans the test environment
            RemoveMedecin(id);

            try
            {
                FindMedecin(id);
                Assert.Fail("Object has been deleted it shouldn't be found");
            }
            catch (ObjectNotFoundException e)
            {
            }
        }

        private int FindAllMedecins()
        {
            try
            {
                return _dao.ListAll().Count;
            }
            catch (ObjectNotFoundException e)
            {
                return 0;
            }
        }


        /**
     * This method ensures that creating an object works. It first finds the object,
     * makes sure it doesn't exist, creates it and checks it then exists.
     */
        [TestMethod]
        public void TestCreateMedecin()
        {
            int id = _dao.GetUniqueId();
            Medecin medecin = null;

            // Ensures that the object doesn't exist
            try
            {
                medecin = FindMedecin(id);
                Assert.Fail("Object has not been created yet it shouldn't be found");
            }
            catch (MedecinNotFoundException e)
            {
            }

            // Creates an object
            CreateMedecin(id);

            // Ensures that the object exists
            try
            {
                medecin = FindMedecin(id);
            }
            catch (MedecinNotFoundException e)
            {
                Assert.Fail("Object has been created it should be found");
            }

            // Ensures that the object exists in the database by executing a sql statement
            try
            {
                FindMedecinSql(id);
            }
            catch (ObjectNotFoundException e)
            {
                Assert.Fail("Medecin has been created it should be found in the database");
            }

            // Checks that it's the right object
            CheckMedecin(medecin, id);

            // Creates an object with the same identifier. An exception has to be thrown
            try
            {
                CreateMedecin(id);
                Assert.Fail("An object with the same id has already been created");
            }
            catch (DuplicateKeyException e)
            {
            }

            // Cleans the test environment
            RemoveMedecin(id);

            try
            {
                FindMedecin(id);
                Assert.Fail("Medecin has been deleted it shouldn't be found");
            }
            catch (ObjectNotFoundException e)
            {
            }

            try
            {
                FindMedecinSql(id);
                Assert.Fail("Medecin has been deleted it shouldn't be found in the database");
            }
            catch (ObjectNotFoundException e)
            {
            }
        }

        private void CheckMedecin(Medecin medecin, int id)
        {
            Assert.AreEqual("nom" + id, medecin.Nom_medecin);
            Assert.AreEqual("prenom" + id, medecin.Prenom_medecin);

        }

        private void RemoveMedecin(int id)
        {
            _dao.Delete(id);
        }

        private void FindMedecinSql(int id)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            String sql;

            connection = Connection.Instance;


            // Select a Row
            sql = "SELECT * FROM MEDECIN WHERE ID = '" + id + "' ";
            command = new SqlCommand(sql, connection);
            connection.Open();
            reader = command.ExecuteReader();
            try
            {
                if (reader.Read() == false)
                    throw new ObjectNotFoundException();

            }
            finally
            {
                // Close
                reader.Close();
                connection.Close();
            }
        }

        private void CreateMedecin(int id)
        {
            Medecin medecin = new Medecin
            {
                Id_medecin = id,
                Nom_medecin = "nom" + id,
                Prenom_medecin = "prénom" + id,
                Tel_medecin = "06" + id
            };
            _dao.Create(medecin);
        }

        private Medecin FindMedecin(int id)
        {

            Medecin medecin = _dao.Retrieve(id);
            return medecin;
        }

        //


    }
}
