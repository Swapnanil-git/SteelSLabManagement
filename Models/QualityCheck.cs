using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelSlabManagement.Models
{
    [Table("QualityCheck", Schema = "vax")]
    public class QualityCheck
    {
        [Key]
        public int QualityCheckId { get; set; }

        [Required]
        public int ProductionId { get; set; }

        [ForeignKey("ProductionId")]
        public Production?Production { get; set; }

        [Required]
        public DateTime CheckDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string InspectorName { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Remarks { get; set; } = String.Empty;

        [Required]
        public bool IsApproved { get; set; }
    }
}
