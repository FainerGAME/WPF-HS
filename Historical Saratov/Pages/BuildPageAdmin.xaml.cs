using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HandyControl.Tools.Extension;
using Historical_Saratov.CustomMessageBox;
using Historical_Saratov.Model;
using Historical_Saratov.Server;
using MySql.Data.MySqlClient;

namespace Historical_Saratov.Pages
{
    public partial class BuildPageAdmin : Page
    {
        // Create a binding source for the ListView
        public ObservableCollection<BuildModel> Builds { get; }

        public BuildPageAdmin()
        {
            InitializeComponent();
          
            this.Builds = new ObservableCollection<BuildModel>();
            this.Loaded += OnPageLoaded;
            
            FillComboBox();
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e) 
            => UpdateBuildModels();

        // Dynamically update the source collection at any time
        private void UpdateBuildModels()
        {
            this.Builds.Clear();

            // Get data from database
            IEnumerable<BuildModel> newBuildModels = BuildManager.GetBuilds();

            // Update source collection with new data from the database
            foreach (BuildModel buildModel in newBuildModels)
            {
                this.Builds.Add(buildModel);
            }
        }

        private void FillComboBox()
        {
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Category", db.GetConnection());
            db.openConnection();
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string ArchName = reader.GetString("ID");
                string Location_ID = reader.GetString("ID");
                string NameCat = reader.GetString("ID");
                CB_Teg.Items.Add(NameCat);
                CB_Arch.Items.Add(ArchName);
                Location.Items.Add(Location_ID);
            }
            db.closeConnection();
        }

        private void Btn_Save_Build(object sender, RoutedEventArgs e)
        {
            if (CB_Arch.Text == " " || TB_Description.Text == " " || TB_Title.Text == " " || BuildData.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"INSERT INTO Builds (Title, Description, BuildDate, ArchitectorID, LocationID, TegID) VALUES ('{TB_Title.Text}', '{TB_Description.Text}', '{BuildData.Text}', '{CB_Arch.Text}', '{Location.Text}', '{CB_Teg.Text}')";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                SaveSnackbar.MessageQueue?.Enqueue("Build save",null,null,null,false,true,TimeSpan.FromSeconds(3));
                SaveSnackbar.Show();
            }
        }

        private void Btn_Update_Build(object sender, RoutedEventArgs e)
        {
            if (CB_Arch.Text == " " || TB_Description.Text == " " || TB_Title.Text == " " || BuildData.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"UPDATE `Builds` SET `Title`='{TB_Title.Text}',`Description`='{TB_Description.Text}', `ArchitectorID`='{CB_Arch.Text}', `LocationID`='{Location.Text}', `TegID`={CB_Teg.Text} WHERE ID= '{TB_ID.Text}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                EditSnackbar.MessageQueue?.Enqueue("Builds update",null,null,null,false,true,TimeSpan.FromSeconds(3));
                EditSnackbar.Show();
                UpdateBuildModels();
            }
        }

        private void Btn_Delete_Build(object sender, RoutedEventArgs e)
        {
            if (CB_Arch.Text == " " || TB_Description.Text == " " || TB_Title.Text == " " || BuildData.Text == " ")
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"DELETE FROM `Builds` WHERE ID= '{TB_ID.Text}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                UpdateBuildModels();
            }
        }
    }
}