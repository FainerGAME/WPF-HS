using System.Collections.Generic;
using Historical_Saratov.Server;
using MySql.Data.MySqlClient;

namespace Historical_Saratov.Model
{
    public class ProfileModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }

        public  string ImagePath { get; set; }
        public byte[] ImageToBytes { get; set; }
    }
    
    public class ProfileManager
    {
        public static List<ProfileModel> GetBuilds()
        {
            List<ProfileModel> items = new List<ProfileModel>();
            DB db = new DB();
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Login", db.GetConnection());
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    items.Add(new ProfileModel { ID = rd.GetInt32(0),FirstName = rd.GetString(1),LastName = rd.GetString(2), Login  = rd.GetString(3), Password = rd.GetString(4), Email = rd.GetString(5), Role = rd.GetInt32(6)});
                }
            }
            return items;
        }
        
    }
}