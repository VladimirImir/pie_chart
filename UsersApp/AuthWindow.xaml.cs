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
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = text_login.Text.Trim();
            string password = text_password.Password.Trim();

            if (login.Length < 5)
            {
                text_login.ToolTip = "Логин не может содержать меньше 5 символов!";
                text_login.Background = Brushes.LightPink;
            }
            else if (password.Length < 5)
            {
                text_password.ToolTip = "Пароль не может содержать меньше 5 символов!";
                text_password.Background = Brushes.LightPink;
            }
            else
            {
                text_login.ToolTip = "";
                text_login.Background = Brushes.Transparent;
                text_password.ToolTip = "";
                text_password.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContex db = new AppContex())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }

                if (authUser != null)
                {
                    //MessageBox.Show("Все отлично!");
                    UserPageWindow userPageWindow = new UserPageWindow(authUser);
                    userPageWindow.Show();
                    //Hide();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Некорректный ввод!");
                }

            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //Hide();
            this.Close();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
