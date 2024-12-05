using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelSlabManagement.Models
{
    [Table("Shipping", Schema = "vax")]
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order ?Order { get; set; }

        [Required]
        public DateTime ShipmentDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Destination { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string ShippedBy { get; set; } = String.Empty;

        [Required]
        public decimal TotalWeight { get; set; } // In tons
    }
}
