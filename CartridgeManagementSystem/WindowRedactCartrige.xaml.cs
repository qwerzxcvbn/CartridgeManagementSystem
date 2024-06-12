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
    /// Логика взаимодействия для WindowRedactCartrige.xaml
    /// </summary>
    public partial class WindowRedactCartrige : Window
    {
        private Cartriges cartridge;
        List<Cartriges> cartr; 
        CartridgeDBEntities CartridgeDBEntities = new CartridgeDBEntities();
        public WindowRedactCartrige(Cartriges selectedCartridge)
        {
            InitializeComponent();      
            cartridge = selectedCartridge;
            cartr = CartridgeDBEntities.Cartriges.Where(c => c.type == cartridge.type && c.model == cartridge.model && c.serialnumb == cartridge.serialnumb && c.gurantee == cartridge.gurantee && c.idState == cartridge.idState && c.idRepair == cartridge.idRepair).ToList();

            Type.Text = cartridge.type;
            Model.Text = cartridge.model;
            SerNumb.Text = cartridge.serialnumb.ToString();
            Garant.Text = cartridge.gurantee.ToString();
            idState = (int)cartridge.idState;
            idRep = cartridge.idRepair != null ? (int)cartridge.idRepair : 0;
            Coment.Text = cartridge.comment;

            ComboState.SelectedIndex = idState - 1; 
            ComboRepair.SelectedIndex = idRep - 1;
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

        private void SaveCartrige_Click(object sender, RoutedEventArgs e)
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
            if (idRep != 0)
            {
                if (CartridgeDBEntities.Repairs.Any(r => r.idRepair == idRep))
                {
                    cartridge.idRepair = idRep;
                }
                else
                {
                    MessageBox.Show("Выбранное значение ремонта не найдено в базе данных");
                    return;
                }
            }

            cartr[0].type = Type.Text;
            cartr[0].model = Model.Text;
            cartr[0].serialnumb = serialnumbValue;
            cartr[0].gurantee = guranteeValue;
            cartr[0].idState = idState;
            cartr[0].idRepair = idRep;
            cartr[0].comment = Coment.Text;   
            
            
            CartridgeDBEntities.SaveChanges();          
            Close();

        }
        private int idRep;
        private void ComboRepair_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboRepair.SelectedIndex == 0)
            {
                idRep = 1;
            }
            else if (ComboRepair.SelectedIndex == 1)
            {
                idRep = 2;
            }
            else if (ComboRepair.SelectedIndex == 2)
            {
                idRep = 3;
            }
        }
    }
}
