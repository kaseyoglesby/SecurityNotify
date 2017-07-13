using SecNotify.Data;
using SecNotify.Models;
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

namespace SecNotify
{
    /// <summary>
    /// Interaction logic for ChooseLocation.xaml
    /// </summary>
    public partial class ChooseLocation : Window
    {
        LocationData locationData = LocationData.GetInstance();

        public ChooseLocation()
        {
            InitializeComponent();

        }

        private void btnSubmitLocation_Click(object sender, RoutedEventArgs e)
        {
            if (cmbLocations.SelectedIndex == -1) {
                MessageBoxResult popup = MessageBox.Show(this, "Please select your current location.", "Message Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            else {
                Location selectedLocation = new Location();
                selectedLocation = locationData.Find(cmbLocations.SelectedIndex);
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
