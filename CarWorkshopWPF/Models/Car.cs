using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWorkshopWPF.Models
{
    public class Car
    {
        [Key] 
        public int Id { get; set; }

        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Customer Owner { get; set; }
    }
}


