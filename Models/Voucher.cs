
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Account.Models
{
    public class Voucher
    {
        [Required]
        public int id { get; set; }
        [Required , Display(Name = "Voucher Date"), DataType(DataType.Date)]

        public DateTime voucherdate { get; set; }
        [Column(TypeName = "nvarchar(100)"), Display(Name = "Voucher No")]
        public string? voucherno { get; set; }
        [Display(Name = "Verified")]
        public int verified { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string? crcoacode { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? crcoaname { get; set; }
        
        [Column(TypeName = "decimal (18,3)")]
        [Display(Name = "Credited Amount")]
        [DisplayFormat(DataFormatString = "₹ {0:0.000}")]
        [DataType(DataType.Currency)]
        public decimal cramt { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? drcoacode { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? drcoaname { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "Debited Amount")]
        [DisplayFormat(DataFormatString = "₹ {0:0.000}")]
        [DataType(DataType.Currency)]
        
        public decimal dramt { get; set; }
    }
}
