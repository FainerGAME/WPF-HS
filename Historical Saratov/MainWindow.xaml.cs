using System;
using System.Collections.Generic;
using System.Data;
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
using Historical_Saratov.CustomMessageBox;
using Historical_Saratov.Model;
using Historical_Saratov.Server;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;


namespace Historical_Saratov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void ToggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }
        
        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void Btn_LogIn_OnClick(object sender, RoutedEventArgs e)
        {
            if (TB_Name.Text == "" || TB_Name == null && PB_Password.Password == "" || PB_Password == null)
            {
                Window window = new ErrorMB();
                window.Show();
            }
            else
            {
                DB db = new DB();
                string userName = TB_Name.Text;
                string userPass = PB_Password.Password;

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM Login WHERE Login = @uL AND Password = @uP AND Role = 2" , db.GetConnection());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userName;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPass;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    global.userid = Convert.ToInt32(table.Rows[0]["ID"].ToString());
                    global.username = table.Rows[0]["Login"].ToString();
                   UserPanel();
                }
                
                else
                {
                    DB dbAdmin = new DB();
                    string userNameAdmin = TB_Name.Text;
                    string userPassAdmin = PB_Password.Password;

                    DataTable tableAdmin = new DataTable();
                    MySqlDataAdapter adapterAdmin = new MySqlDataAdapter();

                    MySqlCommand comm = new MySqlCommand("SELECT * FROM `Login` WHERE `Login` = @ul OR `Email` = @uE AND `Password` = @uP AND `Role` = 1" , dbAdmin.GetConnection());

                    comm.Parameters.Add("@ul", MySqlDbType.VarChar).Value = userNameAdmin;
                    comm.Parameters.Add("@uE", MySqlDbType.VarChar).Value = userNameAdmin;
                    comm.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPassAdmin;

                    adapterAdmin.SelectCommand = comm;
                    adapterAdmin.Fill(tableAdmin);
                    if (tableAdmin.Rows.Count > 0)
                    {
                        AdminPanel();
                    }
                    else
                    {
                        Window window = new UserNotFoundMb();
                        window.Show();
                    }
                }
                
            }
        }

        void UserPanel()
        {
            UserWindow US = new UserWindow();
            Close();
            US.ShowDialog();
        }

        void AdminPanel()
        {
            AdminWindow AW = new AdminWindow();
            Close();
            AW.ShowDialog();
        }

        private void Btn_SingUp_OnClick(object sender, RoutedEventArgs e)
        {
            RegisterWindow RW = new RegisterWindow();
            Close();
            RW.ShowDialog();
        }
    }
}