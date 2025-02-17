using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CarWorkshopWPF.Models;

namespace CarWorkshopWPF.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private CustomerViewModel _customerViewModel;
        private string _newCarLicensePlate;
        private string _newCarMake;
        private string _newCarModel;
        private Car _selectedCar;

        public string NewCarLicensePlate
        {
            get => _newCarLicensePlate;
            set
            {
                _newCarLicensePlate = value;
                OnPropertyChanged(nameof(NewCarLicensePlate));
            }
        }

        public string NewCarMake
        {
            get => _newCarMake;
            set
            {
                _newCarMake = value;
                OnPropertyChanged(nameof(NewCarMake));
            }
        }

        public string NewCarModel
        {
            get => _newCarModel;
            set
            {
                _newCarModel = value;
                OnPropertyChanged(nameof(NewCarModel));
            }
        }

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));

                if (_selectedCar != null)
                {
                    
                    NewCarLicensePlate = _selectedCar.LicensePlate;
                    NewCarMake = _selectedCar.Make;
                    NewCarModel = _selectedCar.Model;
                }
            }
        }

        public ICommand AddCarCommand { get; }
        public ICommand RemoveCarCommand { get; }
        public ICommand EditCarCommand { get; }

        public CarViewModel(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
            AddCarCommand = new RelayCommand(AddCar);
            RemoveCarCommand = new RelayCommand(RemoveCar, CanRemoveCar);
            EditCarCommand = new RelayCommand(EditCar, CanEditCar);
        }

        private void AddCar(object parameter)
        {
            if (_customerViewModel.SelectedCustomer != null &&
                !string.IsNullOrWhiteSpace(NewCarLicensePlate) &&
                !string.IsNullOrWhiteSpace(NewCarMake) &&
                !string.IsNullOrWhiteSpace(NewCarModel))
            {
                var newCar = new Car
                {
                    LicensePlate = NewCarLicensePlate,
                    Make = NewCarMake,
                    Model = NewCarModel
                };

                _customerViewModel.SelectedCustomer.Cars.Add(newCar);
                OnPropertyChanged(nameof(_customerViewModel.SelectedCustomer.Cars));

                
                NewCarLicensePlate = string.Empty;
                NewCarMake = string.Empty;
                NewCarModel = string.Empty;
            }
        }

        private bool CanEditCar(object parameter)
        {
            return _customerViewModel.SelectedCustomer != null && SelectedCar != null;
        }

        private void EditCar(object parameter)
        {
            if (SelectedCar != null)
            {
                SelectedCar.LicensePlate = NewCarLicensePlate;
                SelectedCar.Make = NewCarMake;
                SelectedCar.Model = NewCarModel;

                
                OnPropertyChanged(nameof(_customerViewModel.SelectedCustomer.Cars));
                OnPropertyChanged(nameof(SelectedCar));
            }
        }

        private bool CanRemoveCar(object parameter)
        {
            return _customerViewModel.SelectedCustomer != null && SelectedCar != null;
        }

        private void RemoveCar(object parameter)
        {
            if (_customerViewModel.SelectedCustomer != null && SelectedCar != null)
            {
                _customerViewModel.SelectedCustomer.Cars.Remove(SelectedCar);
                SelectedCar = null;

                OnPropertyChanged(nameof(_customerViewModel.SelectedCustomer.Cars));
                OnPropertyChanged(nameof(SelectedCar));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}















