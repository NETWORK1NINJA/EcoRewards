using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcoRewards.Models
{
    public class RecyclingEntry
    {
        [Key]
        public int RecyclingEntryId { get; set; }

        [Required]
        [Display(Name = "Material Type")]
        public int MaterialTypeId { get; set; }

        [Required]
        [Display(Name = "Drop-Off Point")]
        public int DropOffPointId { get; set; }

        [Required]
        [Display(Name = "Weight (kg)")]
        [Range(0.1, 10000)]
        public decimal Weight { get; set; }

        [Display(Name = "Submission Date")]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        // Resident who submitted the recycling
        public string ResidentId { get; set; }

        // Navigation Properties
        public virtual MaterialType MaterialType { get; set; }

        public virtual DropOffPoint DropOffPoint { get; set; }
    }
}