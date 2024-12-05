using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelSlabManagement.Models
{
    [Table("Production", Schema = "vax")]
    public class Production
    {
        [Key]
        public int ProductionId { get; set; }

        [Required]
        public int OrderId { get; set; } 
        [ForeignKey("OrderId")]
        public Order? Order { get; set; } 

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public decimal ProducedWeight { get; set; } // In tons
    }
}
