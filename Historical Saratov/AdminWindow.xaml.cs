using System.Windows;
using System.Windows.Input;
using Historical_Saratov.Pages;

namespace Historical_Saratov
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Mainn_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new MainPageAdmin();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void Build_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new BuildPageAdmin();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void Architector_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new ArchPageAdmin();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void Profile_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new ProfilePageAdmin();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void Setting_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new SettingPageUser();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void Exit_btn(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}