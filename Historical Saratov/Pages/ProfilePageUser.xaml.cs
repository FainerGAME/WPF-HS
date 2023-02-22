using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Tools.Extension;
using Historical_Saratov.CustomMessageBox;
using Historical_Saratov.Model;
using Historical_Saratov.Server;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;

namespace Historical_Saratov.Pages
{
    public partial class ProfilePageUser : Page
    {
        public ProfilePageUser()
        {
            InitializeComponent();
            DB db = new DB();

            string query = $"SELECT FirstName, LastName, ID, img FROM Login WHERE ID = {ID_Label.Content = global.userid}";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            db.openConnection();
            MySqlDataReader myReader = cmd.ExecuteReader();

            try
            {
                while (myReader.Read())
                {
                    FN_Label.Content = myReader.GetString("FirstName");
                    LN_Label.Content = myReader.GetString("LastName");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}