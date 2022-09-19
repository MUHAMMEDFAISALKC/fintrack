using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Account.Data;
using System;
using System.Linq;


namespace Account.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AccountContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AccountContext>>()))
            {
                if (context.COA.Any())
                {
                    return;   // DB already seeded
                } else {

                    context.COA.AddRange(
                    new COA
                    {AccCode = "1001", Accname = "acc1", ParentId = 0, Acclevel = 1 },
                    new COA
                    {AccCode = "2001", Accname = "acc2", ParentId = 0, Acclevel = 1 },
                    
                    new COA
                    { AccCode = "3001", Accname = "acc3", ParentId = 0, Acclevel = 1 },
                    new COA
                    { AccCode = "4001", Accname = "acc4", ParentId = 0, Acclevel = 1 },
                    new COA
                    { AccCode = "5001", Accname = "acc5", ParentId = 0, Acclevel = 1 },
                     new COA

                     {AccCode = "1002", Accname = "acc6", ParentId = 1, Acclevel = 2 },

                        new COA

                        {AccCode = "2002", Accname = "acc7", ParentId = 2, Acclevel = 2 },

                        new COA

                        { AccCode = "3002", Accname = "acc8", ParentId = 3, Acclevel = 2 },

                        new COA

                        {  AccCode = "4002", Accname = "acc9", ParentId = 4, Acclevel = 2 },

                        new COA

                        { AccCode = "5002", Accname = "acc10", ParentId = 5, Acclevel = 2 },

                        new COA

                        { AccCode = "1003", Accname = "acc11", ParentId = 6, Acclevel = 5 },

                        new COA

                        { AccCode = "2003", Accname = "acc12", ParentId = 7, Acclevel = 5 },

                        new COA

                        { AccCode = "3003", Accname = "acc13", ParentId = 8, Acclevel = 5 },

                        new COA

                        { AccCode = "4003", Accname = "acc14", ParentId = 9, Acclevel = 5 },

                        new COA

                        { AccCode = "5003", Accname = "acc15", ParentId = 10, Acclevel = 5 },

                        new COA

                        { AccCode = "1004", Accname = "acc16", ParentId = 6, Acclevel = 5 },

                        new COA

                        { AccCode = "2004", Accname = "acc17", ParentId = 7, Acclevel = 5 },

                        new COA

                        { AccCode = "3004", Accname = "acc18", ParentId = 8, Acclevel = 3 },

                        new COA

                        { AccCode = "4004", Accname = "acc19", ParentId = 9, Acclevel = 5 },

                        new COA

                        { AccCode = "5004", Accname = "acc20", ParentId = 10, Acclevel = 5 },

                        new COA

                        { AccCode = "1005", Accname = "acc21", ParentId = 6, Acclevel = 5 },

                        new COA

                        { AccCode = "2005", Accname = "acc22", ParentId = 7, Acclevel = 5 },
                        
                        new COA

                        {AccCode = "3005", Accname = "acc23", ParentId = 18, Acclevel = 5 },

                        new COA

                        {AccCode = "4005", Accname = "acc24", ParentId = 9, Acclevel = 5 }
                
                 );
                }
                if (!context.Voucher.Any())
                {
                    context.Voucher.AddRange(
                    new Voucher



                    {
                        voucherdate = DateTime.Parse("2022-1-31"),



                        voucherno = "v1001",
                        verified = 1,
                        crcoacode = "3005",



                        crcoaname = "acc23",
                        //cramt = (decimal)18.500M,
                        //cramt = Math.Round(18.500M, 3) ,
                        //cramt = Decimal.Round(18.599M,3),
                        cramt = 18.500M,



                        drcoacode = null,
                        drcoaname = null,
                        dramt = 0
                    },



new Voucher



{
    voucherdate = DateTime.Parse("2022-1-31"),
    voucherno = "v1001",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "1003",
    drcoaname = "acc11",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-3-25"),
    voucherno = "v1002",
    verified = 0,



    crcoacode = "2005",
    crcoaname = "acc22",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-3-25"),
    voucherno = "v1002",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "1003",
    drcoaname = "acc11",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-13"),
    voucherno = "v1003",



    verified = 1,
    crcoacode = "1003",
    crcoaname = "acc11",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-13"),
    voucherno = "v1003",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "3003",
    drcoaname = "acc13",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-17"),
    voucherno = "v1004",



    verified = 1,
    crcoacode = "5003",
    crcoaname = "acc15",
    cramt = 8.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-17"),
    voucherno = "v1004",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "5004",
    drcoaname = "acc20",
    dramt = 8.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-20"),
    voucherno = "v1005",



    verified = 0,
    crcoacode = "4005",
    crcoaname = "acc24",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-20"),
    voucherno = "v1005",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "1005",
    drcoaname = "acc21",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-23"),
    voucherno = "v1006",



    verified = 1,
    crcoacode = "2004",
    crcoaname = "acc17",
    cramt = 10.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-23"),
    voucherno = "v1006",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "1005",
    drcoaname = "acc21",
    dramt = 10.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-26"),
    voucherno = "v1007",



    verified = 1,
    crcoacode = "3005",
    crcoaname = "acc23",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-4-26"),
    voucherno = "v1007",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "1004",
    drcoaname = "acc16",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-2"),
    voucherno = "v1008",



    verified = 0,
    crcoacode = "1003",
    crcoaname = "acc11",
    cramt = 18.000M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-2"),
    voucherno = "v1008",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "4004",
    drcoaname = "acc19",
    dramt = 18.000M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-10"),
    voucherno = "v1009",



    verified = 1,
    crcoacode = "4003",
    crcoaname = "acc14",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-10"),
    voucherno = "v1009",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "2005",
    drcoaname = "acc22",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-14"),
    voucherno = "v1010",



    verified = 0,
    crcoacode = "2003",
    crcoaname = "acc12",
    cramt = 9.000M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-14"),
    voucherno = "v1010",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "4005",
    drcoaname = "acc24",
    dramt = 9.000M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-21"),
    voucherno = "v1011",



    verified = 0,
    crcoacode = "3003",
    crcoaname = "acc13",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-21"),
    voucherno = "v1011",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "1004",
    drcoaname = "acc16",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-26"),
    voucherno = "v1012",



    verified = 1,
    crcoacode = "2005",
    crcoaname = "acc22",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-5-26"),
    voucherno = "v1012",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "1003",
    drcoaname = "acc11",
    dramt = 18.500M
},



new Voucher
{
    voucherdate = DateTime.Parse("2022-6-1"),
    voucherno = "v1013",

    verified = 1,
    crcoacode = "1005",
    crcoaname = "acc21",
    cramt = 18.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher
{
    voucherdate = DateTime.Parse("2022-6-1"),
    voucherno = "v1013",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "2004",
    drcoaname = "acc17",
    dramt = 18.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-6-4"),
    voucherno = "v1014",



    verified = 0,
    crcoacode = "5003",
    crcoaname = "acc15",
    cramt = 13.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-6-4"),
    voucherno = "v1014",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "3005",
    drcoaname = "acc23",
    dramt = 13.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-6-11"),
    voucherno = "v1015",



    verified = 1,
    crcoacode = "2003",
    crcoaname = "acc12",
    cramt = 19.000M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-6-11"),
    voucherno = "v1015",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "4003",
    drcoaname = "acc14",
    dramt = 19.000M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-6-23"),
    voucherno = "v1016",



    verified = 0,
    crcoacode = "4004",
    crcoaname = "acc19",
    cramt = 21.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-6-23"),
    voucherno = "v1016",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "5004",
    drcoaname = "acc20",
    dramt = 21.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-7-27"),
    voucherno = "v1017",



    verified = 1,
    crcoacode = "3003",
    crcoaname = "acc13",
    cramt = 28.500M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-7-27"),
    voucherno = "v1017",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "2004",
    drcoaname = "acc17",
    dramt = 28.500M
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-8-9"),
    voucherno = "v1018",



    verified = 0,
    crcoacode = "1005",
    crcoaname = "acc21",
    cramt = 31.000M,



    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-8-9"),
    voucherno = "v1018",



    verified = 0,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "4004",
    drcoaname = "acc19",
    dramt = 31.000M
},



new Voucher

{
    voucherdate = DateTime.Parse("2022-12-18"),
    voucherno = "v1019",

    verified = 1,
    crcoacode = "5003",
    crcoaname = "acc15",
    cramt = 24.500M,

    drcoacode = null,
    drcoaname = null,
    dramt = 0
},



new Voucher



{
    voucherdate = DateTime.Parse("2022-12-18"),
    voucherno = "v1019",



    verified = 1,
    crcoacode = null,
    crcoaname = null,
    cramt = 0,



    drcoacode = "3005",
    drcoaname = "acc23",
    dramt = 24.500M
}

                    );
                }
                else
                {
                    return;
                }
                    context.SaveChanges();
            }
        }
    }
}
