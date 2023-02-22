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
using HandyControl.Tools.Extension;
using Historical_Saratov.CustomMessageBox;
using Historical_Saratov.Server;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;


namespace Historical_Saratov
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        
        
        private void Btn_SingUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (TB_FistName.Text == "" || TB_FistName == null || TB_LastName.Text == "" || TB_LastName == null || TB_Name.Text == "" || TB_Name == null || PB_Password.Password == "" || PB_Password == null || PB_Password_Check.Password == "" || PB_Password_Check == null || TB_Email.Text == "" || TB_Name == null )
            {
                Window window = new ErrorMB();
                window.Show();
            }
            else if (PB_Password_Check.Password != PB_Password.Password )
            {
               PasswordSnackBar.MessageQueue?.Enqueue("Password not confirm", null, null, null, false, true, TimeSpan.FromSeconds(5));
               PasswordSnackBar.Show();
            }
            else
            {
                DB db = new DB();
                string query = $"INSERT INTO u1831430_excurtion.Login(FirstName, LastName, Login, Password, Email, Role, img) VALUE ('{TB_FistName.Text}', '{TB_LastName.Text}', '{TB_Name.Text}', '{PB_Password.Password}', '{TB_Email.Text}', '2', 'https://avatars.mds.yandex.net/i?id=56306215539a839cb468aa6f9a7ba967b75a4300-7716570-images-thumbs&n=13')";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                db.openConnection();
                cmd.ExecuteNonQuery();
                db.closeConnection();

                TB_FistName.Text = "";
                TB_LastName.Text = "";
                TB_Name.Text = "";
                TB_Email.Text = "";
                PB_Password.Password = "";
                PB_Password_Check.Password = "";
                
                //PasswordSnackBar.MessageQueue?.Enqueue("Account create", null, null, null, false, true, TimeSpan.FromSeconds(5));
                //PasswordSnackBar.Show();

                Window window = new MainWindow();
                Close();
                window.ShowDialog();
            }
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

        private void Back_Login_Page_Btn(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            Close();
            MW.ShowDialog();
        }
    }
}