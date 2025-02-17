using System.Windows;
using CarWorkshopWPF.ViewModels;

namespace CarWorkshopWPF
{
    public partial class MainWindow : Window
    {
        public CustomerViewModel CustomerVM { get; set; }
        public CarViewModel CarVM { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            
            CustomerVM = new CustomerViewModel();
            CarVM = new CarViewModel(CustomerVM);

            DataContext = this;
        }
    }
}












