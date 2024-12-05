using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelSlabManagement.Models
{
    [Table("Inventory", Schema = "vax")]
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        public int ProductionId { get; set; }

        [ForeignKey("ProductionId")]
        public Production?Production { get; set; } 

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [MaxLength(200)]
        public string Location { get; set; } = String.Empty;
    }
}
