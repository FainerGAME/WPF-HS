using System;   
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using Historical_Saratov.Server;
using MySql.Data.MySqlClient;

namespace Historical_Saratov.Model
{
    public class BuildModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BuildData { get; set; }
        public int Architect { get; set; }
        public int Location { get; set; }
        public int Teg { get; set; }
    }

    public class BuildManager
    {
        public static List<BuildModel> GetBuilds()
        {
            List<BuildModel> items = new List<BuildModel>();
            DB db = new DB();
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Builds", db.GetConnection());
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    items.Add(new BuildModel { ID = rd.GetInt32(0),Title = rd.GetString(1),Description = rd.GetString(2), BuildData = rd.GetString(3), Architect = rd.GetInt32(4), Location = rd.GetInt32(5) ,Teg = rd.GetInt32(6) });
                }
            }
            return items;
        }
        
    }
    
}