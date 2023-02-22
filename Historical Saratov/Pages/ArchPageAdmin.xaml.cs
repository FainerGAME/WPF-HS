using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using HandyControl.Tools.Extension;
using Historical_Saratov.CustomMessageBox;
using Historical_Saratov.Model;
using Historical_Saratov.Server;
using MySql.Data.MySqlClient;

namespace Historical_Saratov.Pages
{
    public partial class ArchPageAdmin : Page
    {
        // Create a binding source for the ListView
        public ObservableCollection<ArchModel> Arch { get; }
        public ArchPageAdmin()
        {
            InitializeComponent();
            
            this.Arch = new ObservableCollection<ArchModel>();
            this.Loaded += OnPageLoaded;
        }
        
        private void OnPageLoaded(object sender, RoutedEventArgs e) 
            => UpdateArchModels();

        // Dynamically update the source collection at any time
        private void UpdateArchModels()
        {
            this.Arch.Clear();

            // Get data from database
            IEnumerable<ArchModel> newArchModels = ArchManager.GetBuilds();

            // Update source collection with new data from the database
            foreach (ArchModel archModel in newArchModels)
            {
                this.Arch.Add(archModel);
            }
        }


        private void Btn_Save_Arch(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_Description.Text == " " || TB_LastName.Text == " " || TB_Patronymic.Text == " " || TB_YOL.Text == " " )
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"INSERT INTO Architector (FirstName, Description, LastName, Patronymic, YearsofLife) VALUES ('{TB_FirstName.Text}', '{TB_Description.Text}', '{TB_LastName.Text}', '{TB_Patronymic.Text}', '{TB_YOL.Text}')";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                SaveSnackbar.MessageQueue?.Enqueue("Architect save",null,null,null,false,true,TimeSpan.FromSeconds(3));
                SaveSnackbar.Show();
                UpdateArchModels();
            }
        }

        private void Btn_Update_Arch(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_Description.Text == " " || TB_LastName.Text == " " || TB_Patronymic.Text == " " || TB_YOL.Text == " " )
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"UPDATE `Architector` SET `FirstName`='{TB_FirstName.Text}',`Description`='{TB_Description.Text}', `LastName`='{TB_LastName.Text}', `Patronymic`='{TB_Patronymic.Text}', `YearsofLife`={TB_YOL.Text} WHERE ID= '{TB_ID.Text}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                EditSnackbar.MessageQueue?.Enqueue("Architect update",null,null,null,false,true,TimeSpan.FromSeconds(3));
                EditSnackbar.Show();
            }
        }

        private void Btn_Delete_Arch(object sender, RoutedEventArgs e)
        {
            if (TB_FirstName.Text == " " || TB_Description.Text == " " || TB_LastName.Text == " " || TB_Patronymic.Text == " " || TB_YOL.Text == " " )
            {
                ErrorMB EM = new ErrorMB();
                EM.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"DELETE FROM `Architector` WHERE ID= '{TB_ID.Text}'";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                UpdateArchModels();
            }
        }
        
        private void Btn_Exel_Arch(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заглушка");
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LVArch.ItemsSource).Refresh();
        }
    }
}