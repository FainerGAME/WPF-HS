using System.Windows;

namespace Historical_Saratov.CustomMessageBox
{
    public partial class UserNotFoundMb : Window
    {
        public UserNotFoundMb()
        {
            InitializeComponent();
        }

        private void Btn_CloseMB_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}