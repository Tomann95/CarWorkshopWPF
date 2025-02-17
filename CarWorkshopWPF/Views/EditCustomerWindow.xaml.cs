using System.Windows;
using CarWorkshopWPF.Models;

namespace CarWorkshopWPF.Views
{
    public partial class EditCustomerWindow : Window
    {
        public EditCustomerWindow(Customer customer)
        {
            InitializeComponent();
            DataContext = customer;
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

