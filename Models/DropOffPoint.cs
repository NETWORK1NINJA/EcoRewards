using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcoRewards.Models
{
    public class DropOffPoint
    {
        [Key]
        public int DropOffPointId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Drop-Off Point")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Contact Number")]
        [Phone]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}