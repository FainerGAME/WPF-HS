using System.Collections.Generic;
using System.Windows.Data;
using Historical_Saratov.Server;
using MySql.Data.MySqlClient;

namespace Historical_Saratov.Model
{
    public class ArchModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string YearsofLive { get; set; }
        
    }
    
    public class ArchManager
    {
        public static List<ArchModel> GetBuilds()
        {
            List<ArchModel> items = new List<ArchModel>();
            DB db = new DB();
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Architector", db.GetConnection());
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    items.Add(new ArchModel { ID = rd.GetInt32(0),FirstName = rd.GetString(1),LastName = rd.GetString(2), Patronymic  = rd.GetString(3), Description = rd.GetString(4), YearsofLive = rd.GetString(5)});
                }
            }
            return items;
        }
        
    }
}