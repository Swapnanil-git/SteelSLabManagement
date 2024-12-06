using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelSlabManagement.Models
{
    [Table("Inventory", Schema = "vax")]
    public class Inventory
    {
        [Key]
        public int BatchId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Grade { get; set; } = string.Empty;

        [Required]
        public double Weight { get; set; } // Weight in kg

        [MaxLength(50)]
        public string Status { get; set; } = "Available";

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }
    }
}
