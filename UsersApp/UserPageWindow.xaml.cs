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
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        private User authUser;

        public UserPageWindow()
        {
            InitializeComponent();

           /* AppContex db = new AppContex();
            List<User> users = db.Users.ToList();

            listOfUsers.ItemsSource = users;*/
        }

        public UserPageWindow(User authUser)
        {
            this.authUser = authUser;
            InitializeComponent();
            identification.Text = authUser.Login;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
