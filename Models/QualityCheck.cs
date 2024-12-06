using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelSlabManagement.Models
{
    [Table("QualityChecks", Schema = "vax")]
    public class QualityCheck
    {
        [Key]
        public int CheckId { get; set; }

        [Required]
        [ForeignKey("Inventory")]
        public int BatchId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Result { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Comments { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CheckedAt { get; set; }

        public Inventory? Inventory { get; set; }
    }
}
