using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcoRewards.Models
{
    public class PointsHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PointsHistoryId { get; set; }

        [Required]
        public int RecyclingEntryId { get; set; }

        [Required]
        public decimal PointsEarned { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAwarded { get; set; }

        // Navigation Property
        public virtual RecyclingEntry RecyclingEntry { get; set; } = new RecyclingEntry();
    }
}