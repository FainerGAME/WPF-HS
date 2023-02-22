using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Historical_Saratov.Pages;

namespace Historical_Saratov
{
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void Main_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new MainPageUser();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void List_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new ListPageUser();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void Map_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new MapPageUser();
            MyFrame.NavigationService.RemoveBackEntry();
        }

        private void Profile_btn(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Content = new ProfilePageUser();
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