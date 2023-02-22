using System.Windows;

namespace Historical_Saratov.CustomMessageBox
{
    public partial class ErrorMB : Window
    {
        public ErrorMB()
        {
            InitializeComponent();
        }

        private void Btn_CloseMB_OnClick(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}