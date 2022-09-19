using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace Account.Models
{
    [Index(nameof(AccCode), IsUnique = true)]
    public class COA
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Account Code")]
        [Column(TypeName = "nvarchar(200)")]

        public string? AccCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Name fo Account")]
        public string? Accname { get; set; }

        [Display(Name = "Parent ID")]
        public int ParentId { get; set; }

        [Display(Name = "Account Level")]
        public int Acclevel { get; set; }
    }
}
