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
    /// Логика взаимодействия для WindowListUser.xaml
    /// </summary>
    public partial class WindowListUser : Window
    {
        CartridgeDBEntities CartridgeDBEntities = new CartridgeDBEntities();
        public WindowListUser()
        {
            InitializeComponent();
            App();          
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            WindowAddUser windowAddUser = new WindowAddUser();
            windowAddUser.Show();
        }
        
        private void App()
        {
            DataUser.ItemsSource = CartridgeDBEntities.Users.ToList();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            App();
        }
    }
}
