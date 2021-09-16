using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AppContex database;

        public MainWindow()
        {
            InitializeComponent();

            database = new AppContex();

            /*DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(2);
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);*/


        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            string login = text_login.Text.Trim();
            string password = text_password.Password.Trim();
            string password_2 = text_password_2.Password.Trim();
            string email = text_email.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                text_login.ToolTip = "Логин не может содержать меньше 5 символов!";
                text_login.Background = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                text_password.ToolTip = "Пароль не может содержать меньше 5 символов!";
                text_password.Background = Brushes.Red;
            }
            else if (password != password_2)
            {
                text_password_2.ToolTip = "Пароль не может содержать меньше 5 символов!";
                text_password_2.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                text_email.ToolTip = "Email не корректный!";
                text_email.Background = Brushes.Red;
            }
            else
            {
                text_login.ToolTip = "";
                text_login.Background = Brushes.Transparent;
                text_password.ToolTip = "";
                text_password.Background = Brushes.Transparent;
                text_password_2.ToolTip = "";
                text_password_2.Background = Brushes.Transparent;
                text_email.ToolTip = "";
                text_email.Background = Brushes.Transparent;

                MessageBox.Show("Регистрация успешна!");

                User user = new User(login, password, email);

                database.Users.Add(user);
                database.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                //Hide();
                Close();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            //Hide();
            this.Close();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
