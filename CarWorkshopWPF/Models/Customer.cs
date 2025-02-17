using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshopWPF.Models
{
    public class Customer
    {
        [Key] 
        public int Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();
    }
}



