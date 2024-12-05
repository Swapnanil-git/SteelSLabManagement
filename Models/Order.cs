using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelSlabManagement.Models
{
    [Table("Orders", Schema = "vax")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(1)]
        public string Grade { get; set; } = string.Empty; // Grade: A, B, or C

        [Required]
        public decimal Length { get; set; } // Length in meters

        [Required]
        public decimal Width { get; set; } // Width in meters

        [Required]
        public decimal Thickness { get; set; } // Thickness in meters
    }
}



