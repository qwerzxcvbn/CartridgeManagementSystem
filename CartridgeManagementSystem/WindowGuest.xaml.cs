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
    /// Логика взаимодействия для WindowGuest.xaml
    /// </summary>
    public partial class WindowGuest : Window
    {
        CartridgeDBEntities CartridgeDBEntities = new CartridgeDBEntities();
        public WindowGuest()
        {
            InitializeComponent();
            App();
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            string searchText = poisk.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                Cartriges foundCartridge = CartridgeDBEntities.Cartriges.FirstOrDefault(c => c.serialnumb.ToString() == searchText);

                if (foundCartridge != null)
                {
                    DataGridCartrige.SelectedItem = foundCartridge;
                    DataGridCartrige.ScrollIntoView(foundCartridge);
                }
                else
                {
                    MessageBox.Show("Картридж с указанным серийным номером не найден.");
                }
            }
            App();
        }
        private void App()
        {
            DataGridCartrige.ItemsSource = CartridgeDBEntities.Cartriges.ToList();
        }
    }
}
