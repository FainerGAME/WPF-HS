using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;


namespace Historical_Saratov.Pages
{
    public partial class SettingPageUser : Page
    {
        public SettingPageUser()
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
                    TB_FirstName.Text = myReader.GetString("FirstName");
                    TB_LastName.Text = myReader.GetString("LastName");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void Btn_LogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("Historical Saratov.exe");
            Application.Current.Shutdown();
        }

        private void Btn_EditProfile_OnClick(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_LastName.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"UPDATE `Login` SET `FirstName`= '{TB_FirstName.Text}',`LastName`= '{TB_LastName.Text}' WHERE ID= '{ID_Label.Content = global.userid}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                EditSnackbar.MessageQueue?.Enqueue("FirstName and LastName has update",null,null,null,false,true,TimeSpan.FromSeconds(3));
                EditSnackbar.Show();
            }
        }

        private void Btn_DeleteProfile_OnClick(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_LastName.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"DELETE FROM `Login` WHERE ID= '{ID_Label.Content = global.userid}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                Process.Start("Historical Saratov.exe");
                Application.Current.Shutdown();
            }
            //DeleteAlert DA = new DeleteAlert();
            //DA.ShowDialog();
        }

        private void Btn_SelectImg_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();
            opf.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png";
            opf.DefaultExt = ".png";
            ImageBox.Text = opf.FileName;
            ImageSource imageSource = new BitmapImage(new Uri(ImageBox.Text));
            AvatarEdit.Source = imageSource;
        }
        
        private void Btn_AddImg_OnClick(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            ProfileModel images = new ProfileModel();
            images.ImagePath = ImageBox.Text;
            images.ImageToBytes = File.ReadAllBytes(ImageBox.Text);
            string query = "INSERT INTO Login(img) VALUES ('@image', img)";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.Add(new MySqlParameter("@image", File.ReadAllBytes(ImageBox.Text)));
            db.openConnection();
            cmd.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}