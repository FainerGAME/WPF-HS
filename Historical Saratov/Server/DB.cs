using MySql.Data.MySqlClient;
namespace Historical_Saratov.Server
{
    public class DB
    {
        private MySqlConnection connectionString = new MySqlConnection("server=31.31.198.5; username=u1831430_fg; password=GreferChenal3432; database=u1831430_excurtion");

        public void openConnection()
        {
            if (connectionString.State == System.Data.ConnectionState.Closed)
            {
                connectionString.Open();
            }
        }
        
        public void closeConnection()
        {
            if (connectionString.State == System.Data.ConnectionState.Open)
            {
                connectionString.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connectionString;
        }
    }
}