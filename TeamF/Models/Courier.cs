using System.ComponentModel.DataAnnotations;
//courier Partners 
namespace TeamF.Models
{
    public class Courier
    {
        [Key]
        public int CourierID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string VehicleType { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Available";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
