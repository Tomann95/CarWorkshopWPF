using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CarWorkshopWPF.Models;

namespace CarWorkshopWPF.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        private string _newCustomerName;
        private string _newCustomerPhone;
        private Customer _selectedCustomer;

        public string NewCustomerName
        {
            get => _newCustomerName;
            set
            {
                _newCustomerName = value;
                OnPropertyChanged(nameof(NewCustomerName));
            }
        }

        public string NewCustomerPhone
        {
            get => _newCustomerPhone;
            set
            {
                _newCustomerPhone = value;
                OnPropertyChanged(nameof(NewCustomerPhone));
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
                OnPropertyChanged(nameof(SelectedCustomerCars));

                
                if (_selectedCustomer != null)
                {
                    NewCustomerName = _selectedCustomer.Name;
                    NewCustomerPhone = _selectedCustomer.PhoneNumber;
                }
            }
        }

        public ObservableCollection<Car> SelectedCustomerCars => SelectedCustomer?.Cars ?? new ObservableCollection<Car>();

        public ICommand AddCustomerCommand { get; }
        public ICommand RemoveCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }

        public CustomerViewModel()
        {
            AddCustomerCommand = new RelayCommand(AddCustomer);
            RemoveCustomerCommand = new RelayCommand(RemoveCustomer, CanRemoveCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer, CanEditCustomer);
        }

        private void AddCustomer(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewCustomerName) && !string.IsNullOrWhiteSpace(NewCustomerPhone))
            {
                var newCustomer = new Customer
                {
                    Name = NewCustomerName,
                    PhoneNumber = NewCustomerPhone,
                    Cars = new ObservableCollection<Car>()
                };

                Customers.Add(newCustomer);
                SelectedCustomer = newCustomer;

                OnPropertyChanged(nameof(Customers));
                OnPropertyChanged(nameof(SelectedCustomer));
                OnPropertyChanged(nameof(SelectedCustomerCars));

                
                NewCustomerName = string.Empty;
                NewCustomerPhone = string.Empty;
            }
        }

        private bool CanEditCustomer(object parameter)
        {
            return SelectedCustomer != null;
        }

        private void EditCustomer(object parameter)
        {
            if (SelectedCustomer != null)
            {
                SelectedCustomer.Name = NewCustomerName;
                SelectedCustomer.PhoneNumber = NewCustomerPhone;

                
                OnPropertyChanged(nameof(Customers));
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        private bool CanRemoveCustomer(object parameter)
        {
            return SelectedCustomer != null;
        }

        private void RemoveCustomer(object parameter)
        {
            if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;

                OnPropertyChanged(nameof(Customers));
                OnPropertyChanged(nameof(SelectedCustomer));
                OnPropertyChanged(nameof(SelectedCustomerCars));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}



















