using System.Windows;
using CarWorkshopWPF.Models;

namespace CarWorkshopWPF.Views
{
    public partial class EditCarWindow : Window
    {
        public EditCarWindow(Car car)
        {
            InitializeComponent();
            DataContext = car;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

