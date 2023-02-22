using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Tools.Extension;
using Historical_Saratov.CustomMessageBox;
using Historical_Saratov.Model;
using Historical_Saratov.Server;
using MySql.Data.MySqlClient;

namespace Historical_Saratov.Pages
{
    public partial class ProfilePageAdmin : Page
    {
        public ObservableCollection<ProfileModel> Profiles { get; }
        public ProfilePageAdmin()
        {
            InitializeComponent();
            
            this.Profiles = new ObservableCollection<ProfileModel>();
            this.Loaded += OnPageLoaded;
            FillComboBox();
        }
        
        private void OnPageLoaded(object sender, RoutedEventArgs e) 
            => UpdateProfileModels();
        
        private void UpdateProfileModels()
        {
            this.Profiles.Clear();

            // Get data from database
            IEnumerable<ProfileModel> newProfileModels = ProfileManager.GetBuilds();

            // Update source collection with new data from the database
            foreach (ProfileModel profilehModel in newProfileModels)
            {
                this.Profiles.Add(profilehModel);
            }
        }
        private void Btn_Save_Profile(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_Email.Text == " " || TB_LastName.Text == " " || TB_Password.Text == " " || TB_Login.Text == " " || CB_Role.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"INSERT INTO Login (FirstName, LastName, Login, Password, Email, Role) VALUES ('{TB_FirstName.Text}', '{TB_LastName.Text}', '{TB_Login.Text}', '{TB_Password.Text}', '{TB_Email.Text}', '{CB_Role.Text}')";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                SaveSnackbar.MessageQueue?.Enqueue("Profile save",null,null,null,false,true,TimeSpan.FromSeconds(3));
                SaveSnackbar.Show();
                UpdateProfileModels();
            }
        }
        
        private void FillComboBox()
        {
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Permission", db.GetConnection());
            db.openConnection();
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string NameRole = reader.GetString("ID");
                CB_Role.Items.Add(NameRole);
            }
            db.closeConnection();
        }

        private void Btn_Update_Profile(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_Email.Text == " " || TB_LastName.Text == " " || TB_Password.Text == " " || TB_Login.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"UPDATE `Login` SET `FirstName`='{TB_FirstName.Text}', `LastName`='{TB_LastName.Text}', `Login`='{TB_Login.Text}', `Password`={TB_Password.Text}, `Email`={TB_Email.Text}, `Role`={CB_Role.Text} WHERE ID='{TB_ID.Text}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                EditSnackbar.MessageQueue?.Enqueue("Profile update",null,null,null,false,true,TimeSpan.FromSeconds(3));
                EditSnackbar.Show();
                UpdateProfileModels();
            }
        }

        private void Btn_Delete_Profile(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_Email.Text == " " || TB_LastName.Text == " " || TB_Password.Text == " " || TB_Login.Text == " " || CB_Role.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"DELETE FROM `Login` WHERE ID= '{TB_ID.Text}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                UpdateProfileModels();
            }
        }
    }
}