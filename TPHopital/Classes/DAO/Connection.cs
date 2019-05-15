using System.Data.SqlClient;

namespace TPHopital.Classes.DAO
{
    public class Connection
    {
        private static SqlConnection instance = null;
        private static object _lock = new object();

        public static SqlConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
<<<<<<< HEAD
                        instance = new SqlConnection(@"Data Source=Data Source=(localDb)\HopitalDB;Integrated Security=True");
=======
                        instance = new SqlConnection(@"Data Source=(localDb)\HopitalDB;Integrated Security=True");
>>>>>>> 41c10ecd29192325b8030bbd3bf56eb4849f08c5
                    return instance;
                }
            }
        }
    }
}