using System;
using System.Windows;

namespace Historical_Saratov.CustomMessageBox
{
    public partial class ChapchaMB : Window
    {
        public ChapchaMB()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Capcha(object sender, RoutedEventArgs e)
        {
            if (Capcha_gen.Text==TB_Capcha.Text)
            {
               Close();
            }
            else
            {
                MessageBox.Show("Капча не верна");
            }
        }

        private void Card_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int num = rand.Next(6, 8);
            string captcha = "";
            int totle = 0;
            do
            {
                int chr = rand.Next(48, 123);
                if ((chr >= 48 && chr <= 57) ||(chr >= 65 && chr <= 90)||(chr >= 97 && chr <= 122))
                {
                    captcha += (char) chr;
                    totle++;
                    if (totle==num)
                        break;
                    {
                        
                    }
                }
            } while (true);

            Capcha_gen.Text = captcha;
        }
    }
}