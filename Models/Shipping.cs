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
        public Order? Order { get; set; }

        [MaxLength(100)]
        public string? TrackingId { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        public DateTime? ShippedAt { get; set; }
    }
}
