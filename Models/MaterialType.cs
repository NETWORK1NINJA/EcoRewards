using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoRewards.Models
{
    public class MaterialType
    {
        [Key]
        public int MaterialTypeId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Material Name")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public virtual ICollection<RecyclingEntry> RecyclingEntries { get; set; }

        [Required]
        [Display(Name = "Points Per Kg")]
        public decimal PointsPerKg { get; set; }

        [Required]
        [Display(Name = "CO₂ Saved Per Kg")]
        public decimal CO2PerKg { get; set; }

 }   }