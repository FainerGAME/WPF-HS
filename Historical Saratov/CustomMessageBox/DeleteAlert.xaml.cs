using System.Windows;

namespace Historical_Saratov.CustomMessageBox
{
    public partial class DeleteAlert : Window
    {
        public DeleteAlert()
        {
            InitializeComponent();
        }

        private void Btn_CloseMB_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Delete_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}