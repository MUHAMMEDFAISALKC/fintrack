

using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Account.Models
{
    public class CombinedAccount
    {
        public List<COA>? COA { get; set; }
        public List<Voucher>? Voucher { get; set; }

        [Column(TypeName = "decimal (18,3)")]
        [Display(Name = "Balance")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public List<Status>?Status{ get; set; }

        public List<TreeList>? treeList { get; set; }
        public List<TreeView>? treeView { get; set; }

        //------------------
        public class TreeView
        {
            public List<TreeList>? treeList { get; set; }
        }
         public class TreeList
        {
            public List<Status> Header { get; set; }
            public List<Status> Items { get; set; }
            public static List<TreeList> GetData(TreeList val)
            {
                return new List<TreeList>
                {
                    new TreeList
                    {
                        Header = val.Header,
                        Items = val.Items
                    }
                };
            }
        }

    }
}
