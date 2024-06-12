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
    /// Логика взаимодействия для WindowAddCartridge.xaml
    /// </summary>
    public partial class WindowAddCartridge : Window
    {
        CartridgeDBEntities CartridgeDBEntities = new CartridgeDBEntities();
        public WindowAddCartridge()
        {
            InitializeComponent();
        }

        private void AddCartridge_Click(object sender, RoutedEventArgs e)
        {
            int serialnumbValue;
            if (!int.TryParse(SerNumb.Text, out serialnumbValue))
            {
                MessageBox.Show("Введите корректное значение для серийного номера");
                return;
            }
            int guranteeValue;
            if (!int.TryParse(Garant.Text, out guranteeValue))
            {
                MessageBox.Show("Введите корректное значение для гарантии");
                return;
            }

            Cartriges cartriges = new Cartriges
            {
                type = Type.Text,
                model = Model.Text,
                serialnumb = serialnumbValue,
                gurantee = guranteeValue,
                idState = idState,
                comment = Coment.Text,
                date = DateTime.Now
            };
            CartridgeDBEntities.Cartriges.Add(cartriges);
            CartridgeDBEntities.SaveChanges();
            Close();
        }

        private int idState;
        private void ComboState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboState.SelectedIndex == 0)
            {
                idState = 1;
            }
            if (ComboState.SelectedIndex == 1)
            {
                idState = 2;
            }
            if (ComboState.SelectedIndex == 2)
            {
                idState = 3;
            }
        }
    }
}
