using System.Data.SqlClient;

namespace TPHopitalWpfEF.Classes.DAO
{
    public class Connection
    {
        private static SqlConnection instance = null;
        private static readonly object _lock = new object();

        public static SqlConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)

                        instance = new SqlConnection(@"Data Source=(localDb)\HopitalDB;Integrated Security=True");

                    return instance;
                }
            }
        }
    }
}