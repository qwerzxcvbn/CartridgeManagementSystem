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

namespace CartridgeManagementSystem
{
    /// <summary>
    /// Логика взаимодействия для WindowAddUser.xaml
    /// </summary>
    public partial class WindowAddUser : Window
    {
        CartridgeDBEntities CartridgeDBEntities = new CartridgeDBEntities();
        public WindowAddUser()
        {
            InitializeComponent();
        }

        private int idRole;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Role.SelectedIndex == 0)
            {
                idRole = 1;
            }
            else if (Role.SelectedIndex == 1)
            {
                idRole = 2;
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            Users User = new Users
            {
                login = Login.Text,
                pass = Pass.Text,
                idRole = idRole
            };

            CartridgeDBEntities.Users.Add(User);
            CartridgeDBEntities.SaveChanges();
            Close();
        }
    }
}
