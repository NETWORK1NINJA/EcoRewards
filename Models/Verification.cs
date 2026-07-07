using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcoRewards.Models
{
    public enum Status
    {
        Pending,
        Approved,
        Rejected
    }
    public class Verification
    {
        [Key]
        public int VerificationId { get; set; }

        [Required]
        public int RecyclingEntryId { get; set; }

        [Required]
        [Display(Name = "Verification Date")]
        [DataType(DataType.Date)]
        public DateTime VerificationDate { get; set; }

        [Required]
        public Status  Verificationstatus{ get; set; }=Status.Pending;

        [StringLength(300)]
        public string Comments { get; set; }

        // Collection Officer who performed the verification
        public string OfficerId { get; set; }

        // Navigation Property
        public virtual RecyclingEntry RecyclingEntry { get; set; }
    }
}