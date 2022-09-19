using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Account.Models;

namespace Account.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext (DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        public DbSet<Account.Models.COA> COA { get; set; } = default!;

        public DbSet<Account.Models.Voucher>? Voucher { get; set; }
    }
}
