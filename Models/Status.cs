using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Account.Models
{
    [Index(nameof(AccCode), IsUnique = true)]
    public class Status
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




        [Column(TypeName = "nvarchar(100)")]
        public string? crcoacode { get; set; }



        [Column(TypeName = "decimal (18,3)")]
        [Display(Name = "Credited Amount")]
        [DisplayFormat(DataFormatString = "₹ {0:0.000}")]
        [DataType(DataType.Currency)]
        public decimal cramt { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? drcoacode { get; set; }


        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "Debited Amount")]
        [DisplayFormat(DataFormatString = "₹ {0:0.000}")]
        [DataType(DataType.Currency)]

        public decimal dramt { get; set; }

        [Column(TypeName = "decimal (18,3)")]
        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "₹ {0:0.000}")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
    }


    [Index(nameof(AccCode), IsUnique = true)]
    public class Accdisplay1
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

        [Required]
        [Display(Name = "Voucher Date"), DataType(DataType.Date)]

        public DateTime voucherdate { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Voucher No")]
        public string? voucherno { get; set; }
        [Display(Name = "Verified")]
        public int verified { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string? crcoacode { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? crcoaname { get; set; }

        [Column(TypeName = "decimal (18,3)")]
        [Display(Name = "Credited Amount")]
        //[RegularExpression(@"^\d+\.\d{0,3}$")]
        [DataType(DataType.Currency)]
        public decimal cramt { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? drcoacode { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? drcoaname { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "Debited Amount")]
        [DataType(DataType.Currency)]
        //[RegularExpression(@"^\d+\.\d{0,3}$")]
        public decimal dramt { get; set; }
        
    }

    

}

