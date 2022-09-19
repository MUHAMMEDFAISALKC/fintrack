using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Account.Data;
using Account.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Http.Features;

namespace Account.Controllers
{
    public class AccountsController : Controller
    {
        
        private readonly AccountContext _context;
        public AccountsController(AccountContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()

        {
            var COA = from a in _context.COA
                      orderby a.ParentId
                      select a;
            var Voucher = from vo in _context.Voucher
                          select vo;

            var CombinedTable1 = (from a in COA.AsEnumerable()
                                  join vo in Voucher.AsEnumerable()
                                  on a.AccCode equals vo.crcoacode
                                  into table1
                                  from d in table1.AsEnumerable()
                                  orderby a.AccCode
                                  select new Status
                                  {
                                      ID= a.ID,
                                      AccCode = a.AccCode,
                                      Accname = a.Accname,
                                      ParentId = a.ParentId,
                                      Acclevel = a.Acclevel,
                                      crcoacode = d.crcoacode,
                                      cramt = d.cramt,
                                      drcoacode = d.drcoacode,
                                      dramt = d.dramt,
                                      Balance =0
                                  }).ToList();
                               

//new { AccCode = (string)"", Accname = (string)"", Acclevel = (int)0, crcoacode = (decimal)0, cramt = (decimal)0 }

var ids = (from n in CombinedTable1.AsEnumerable()
                       select n.AccCode).Distinct().ToList();
            var orgIds =from a in _context.COA
                         orderby a.AccCode
                         select a.AccCode;
            //var finalList= new[] { AccCode = (string)"", Accname = (string)"", Acclevel = (int)0, crcoacode = (decimal)0, cramt = (decimal)0 };
            var finalList = new List<Status>();

            for (int i = 0; i < ids.Count; i++)
            {
                if (orgIds.Contains(ids[i])) {
                    var accQuery = (from n in CombinedTable1.AsEnumerable()
                                    select n).ToList();

                    var AccEntry = (accQuery.Where(x => x.AccCode!.Contains(ids[i]))).ToList();

                    decimal cramout = 0;
                    for (int j = 0; j < 1; j++)
                    {
                        cramout = AccEntry.AsEnumerable().AsEnumerable().Sum(x => x.cramt);

                        var newEntry = new List<Status>() {
                                 new Status() {
                                ID = AccEntry[0].ID,
                                AccCode = AccEntry[0].AccCode,
                                Accname = AccEntry[0].Accname,
                                ParentId = AccEntry[0].ParentId,
                                Acclevel = AccEntry[0].Acclevel,
                                crcoacode = AccEntry[0].crcoacode,
                                cramt = cramout,
                                drcoacode = AccEntry[0].drcoacode,
                                dramt = AccEntry[0].dramt,
                                Balance = cramout
                                }
                            };


                        finalList.AddRange(newEntry);
                    }
                }
                //AccEntry.CopyTo(NewEntry);
                //NewEntry[0].cramt = cramt; 
            }
            finalList.Distinct().ToList();

            System.Diagnostics.Debug.WriteLine("finalCredit data cout" + finalList.Count);


            /*
            for (int i = 0; i < CombinedTable1.Count; i++)
            {
                if CombinedTable1.GroupBy CombinedTable1.AccCode   
                newCoaVTable.Add(i);
            }
            */

            var CombinedTable2 = (from a in COA.AsEnumerable()
                                 join vo in Voucher.AsEnumerable()
                                 on a.AccCode equals vo.drcoacode
                                 into Table2
                                 from t in Table2.AsEnumerable() 
                                 orderby a.AccCode
                                 select new
                                 {
                                     ID = a.ID,
                                     AccCode = a.AccCode,
                                     Accname = a.Accname,
                                     ParentId = a.ParentId,
                                     Acclevel = a.Acclevel,
                                     crcoacode = t.crcoacode,
                                     cramt = t.cramt,
                                     drcoacode = t.drcoacode,
                                     dramt = t.dramt,
                                     Balance =0
                                 }).ToList();

            var ids1 = (from n in CombinedTable2.AsEnumerable()
                       select n.drcoacode).Distinct().ToList();
            var finalList1 = new List<Status>();
            for (int i = 0; i < ids1.Count; i++)
            {
                var accQuery = (from n in CombinedTable2.AsEnumerable()
                                select n).ToList();

                var AccEntry = (accQuery.Where(x => x.drcoacode!.Contains(ids1[i]))).ToList();
                
                decimal dramout = 0;
                for (int j = 0; j < 1; j++)
                {
                    dramout = AccEntry.AsEnumerable().AsEnumerable().Sum(x => x.dramt);

                    var newEntry = new List<Status>() {
                        new Status() {
                        ID= AccEntry[0].ID,
                        AccCode = AccEntry[0].AccCode,
                        Accname = AccEntry[0].Accname,
                        ParentId = AccEntry[0].ParentId,
                        Acclevel = AccEntry[0].Acclevel,
                        crcoacode = AccEntry[0].crcoacode,
                        cramt = AccEntry[0].cramt,
                        drcoacode = AccEntry[0].drcoacode,
                        dramt = dramout,
                        Balance = dramout,
                        }
                    };
                    finalList1.AddRange(newEntry);
                }
                //AccEntry.CopyTo((dynamic)newEntry);
                //newEntry[0].cramt = dramt;
            }
            finalList1.Distinct().ToList();
            System.Diagnostics.Debug.WriteLine("finaldebit data cout" + finalList1.Count);



            var finalStatus1 = (from c in finalList.AsEnumerable()
                              join d in finalList1.AsEnumerable()
                              on c.AccCode equals d.drcoacode
                              into table3
                              from t in table3.AsEnumerable()
                              orderby c.AccCode
                              select new
                              {
                                  ID= c.ID,
                                  AccCode = c.AccCode,
                                  Accname = c.Accname,
                                  ParentId = c.ParentId,
                                  Acclevel = c.Acclevel,
                                  crcoacode = c.crcoacode,
                                  cramt = c.cramt,
                                  drcoacode = t.drcoacode,
                                  dramt = t.dramt,
                                  Balance = c.cramt - t.dramt
                              }).ToList();

            // Acounts with only Credit trasaction or Debit Transaction

            var odds = ((finalList.AsEnumerable())
                        .Union(finalList1.AsEnumerable())).ToList();
            /*

            var odds = ((from c in finalList.AsEnumerable()
                         where (c.cramt != 0 && c.dramt == 0)
                         select c)
                        .Union(from a in finalList1.AsEnumerable()
                               where (a.dramt != 0 && a.cramt == 0)
                               select a
                               )).ToList();
            var odds = (from o in odd.AsEnumerable()
                        orderby o.AccCode
                        select o).ToList();
           */

            

            var idExtract = (from n in finalStatus1
                             orderby n.AccCode
                             select n.AccCode).ToList();
            var oddsNumber = 0;

            var VoucherExt = Voucher.ToList();
            for (int i = 0; i < VoucherExt.Count; i++)
            {
                if (VoucherExt[i].crcoacode != null || VoucherExt[i].drcoacode != null)
                {
                    if (!idExtract.Contains(VoucherExt[i].crcoacode + VoucherExt[i].drcoacode))
                    {
                        oddsNumber++;
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("oddsNumber is " + oddsNumber);
            

            var oddList = new List<Status>();

            
            for (int i = 0; i < oddsNumber; i++)
            {
                var ffdata = new List<Status>(){
                    new Status
                    {
                    ID = 0,
                    AccCode = "",
                    Accname = "",
                    ParentId = 0,
                    Acclevel = 0,
                    crcoacode = "",
                    cramt = 0,
                    drcoacode = "",
                    dramt = 0,
                    Balance = 0
                    }
                };
                oddList.AddRange(ffdata);
            }


            int re = 0;
            int repeatation = 0;
            for (int e = 0; e < VoucherExt.Count; e++)
            {
                if (VoucherExt[e].crcoacode != null || VoucherExt[e].drcoacode != null)
                {
                    if (!idExtract.Contains(VoucherExt[e].crcoacode + VoucherExt[e].drcoacode))
                    {
                        repeatation++;
                        for (int j = 0; j < 10; j++)
                        {
                            if (j == 0)
                            {
                                oddList[re].ID = VoucherExt[e].id;
                                
                            }
                            if (j == 1)
                            {
                                if (VoucherExt[e].crcoacode != null)
                                {
                                    oddList[re].AccCode = VoucherExt[e].crcoacode;
                                }
                                if (VoucherExt[e].drcoacode != null)
                                {
                                    oddList[re].AccCode = VoucherExt[e].drcoacode;
                                }
                                
                            }
                            if (j == 2)
                            {
                                if (VoucherExt[e].crcoacode != null)
                                {
                                    oddList[re].Accname = VoucherExt[e].crcoaname;
                                }
                                if (VoucherExt[e].drcoacode != null)
                                {
                                    oddList[re].Accname = VoucherExt[e].drcoaname;
                                }
                                
                            }
                            if (j == 3)
                            {
                                var parentID = new List<int>();
                                if (VoucherExt[e].crcoacode != null)
                                {
                                    parentID = (from c in COA
                                                where c.AccCode == VoucherExt[e].crcoacode
                                                select c.ParentId
                                                ).ToList();
                                }
                                if (VoucherExt[e].drcoacode != null)
                                {
                                    parentID = (from c in COA
                                                where c.AccCode == VoucherExt[e].drcoacode
                                                select c.ParentId
                                                ).ToList();
                                }
                                oddList[re].ParentId = parentID[0];
                            }
                            if (j == 4)
                            {
                                int levelcheck = 0;
                                if (VoucherExt[e].crcoacode != null)
                                {
                                    levelcheck = (from c in COA
                                                      where c.AccCode == VoucherExt[e].crcoacode
                                                      select c.Acclevel).FirstOrDefault();
                                }
                                if (VoucherExt[e].drcoacode != null)
                                {
                                    levelcheck = (from c in COA
                                                      where c.AccCode == VoucherExt[e].drcoacode
                                                      select c.Acclevel).FirstOrDefault();
                                }


                                oddList[re].Acclevel = levelcheck;
                               
                            }
                            if (j == 5)
                            {
                                oddList[re].crcoacode = VoucherExt[e].crcoacode;
                                

                            }
                            if (j == 6)
                            {
                                oddList[re].cramt = VoucherExt[e].cramt;
                               
                            }
                            if (j == 7)
                            {
                                oddList[re].drcoacode = VoucherExt[e].drcoacode;
                                
                            }
                            if (j == 8)
                            {
                                oddList[re].dramt = VoucherExt[e].dramt;
                                
                            }
                            if (j == 9)
                            {
                                oddList[re].Balance = VoucherExt[e].cramt - VoucherExt[e].dramt;
                                
                            }
                        }
                        re++;
                    }
                }
            }

            // Extracting one entry for all Credit and Debit transaction of one account
            var idOdds = (from n in oddList.AsEnumerable()
                          where n.crcoacode != null
                         orderby n.crcoacode
                         select n.crcoacode)
                           .Union(from n in oddList.AsEnumerable()
                                  where n.drcoacode != null
                                  orderby n.drcoacode
                                  select n.drcoacode).Distinct().ToList();

            // order in ascending 
            var idOdd = (from z in idOdds.AsEnumerable()
                    orderby z ascending
                    select z).ToList();
            // ids in records       
            var orgnIds = (from a in _context.COA
                           orderby a.AccCode
                           select a.AccCode).Distinct().ToList(); ;

            for (int i=0; i<idOdd.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("id:" + idOdd[i] + ":this");
            }

            
            // Checking are ids availlable in records
            int Hi = 1;
            for (int i = 0; i < idOdd.Count; i++)
            {
                if (orgnIds.Contains(idOdd[i]))
                { 
                    System.Diagnostics.Debug.WriteLine(idOdd[i] + " oddId and total count= " + Hi);
                }
                else
                {
                    idOdd.Remove(idOdd[i]);
                    System.Diagnostics.Debug.WriteLine("removed this:" + idOdd[i] + "/");
                }
                Hi++;
            }

            /* -------------------- Odd Credit and Debit Transactions ------------------ */
            // defining a list for odd credit or debit transactions
            var oddExtract = new List<Status>();

            // Extracting one entry for all Credit transaction of one account
            // oddCredit ids
            var idOddCr = (from n in oddList.AsEnumerable()
                           where (n.crcoacode != null)
                           orderby n.AccCode ascending
                           select n.crcoacode
                           ).Distinct().ToList();

            for (int i = 0; i < idOddCr.Count; i++)
            {
                if (orgnIds.Contains(idOddCr[i]))
                {
                    var accQuery = (from n in oddList.AsEnumerable()
                                    where (n.crcoacode != null)
                                    orderby n.AccCode ascending
                                    select n).ToList();

                    var AccEntry = (accQuery.Where(x => x.AccCode!.Contains(idOddCr[i]))).ToList();

                    decimal cramout = 0;
                    
                    cramout = AccEntry.AsEnumerable().AsEnumerable().Sum(x => x.cramt);

                    var newEntry = new List<Status>() {
                                 new Status() {
                                ID = AccEntry[0].ID,
                                AccCode = AccEntry[0].AccCode,
                                Accname = AccEntry[0].Accname,
                                ParentId = AccEntry[0].ParentId,
                                Acclevel = AccEntry[0].Acclevel,
                                crcoacode = AccEntry[0].crcoacode,
                                cramt = cramout,
                                drcoacode = AccEntry[0].drcoacode,
                                dramt = AccEntry[0].dramt,
                                Balance = cramout - AccEntry[0].dramt
                                }
                            };
                    oddExtract.AddRange(newEntry);   
                }
            }
            oddExtract.Distinct().ToList();

            // Extracting one entry for all Debit transaction of one account
            // oddDebit ids
            var idOddDr = (from n in oddList.AsEnumerable()
                           where (n.drcoacode != null)
                           orderby n.AccCode ascending
                           select n.drcoacode
                           ).Distinct().ToList();

            for (int i = 0; i < idOddDr.Count; i++)
            {
                if (orgnIds.Contains(idOddDr[i]))
                {
                    var accQuery = (from n in oddList.AsEnumerable()
                                    where (n.drcoacode != null)
                                    orderby n.AccCode ascending
                                    select n).ToList();

                    var AccEntry = (accQuery.Where(x => x.AccCode!.Contains(idOddDr[i]))).ToList();

                    decimal dramout = 0;

                    dramout = AccEntry.AsEnumerable().AsEnumerable().Sum(x => x.dramt);

                    var newEntry = new List<Status>() {
                                 new Status() {
                                ID = AccEntry[0].ID,
                                AccCode = AccEntry[0].AccCode,
                                Accname = AccEntry[0].Accname,
                                ParentId = AccEntry[0].ParentId,
                                Acclevel = AccEntry[0].Acclevel,
                                crcoacode = AccEntry[0].crcoacode,
                                cramt = AccEntry[0].cramt,
                                drcoacode = AccEntry[0].drcoacode,
                                dramt = dramout,
                                Balance = AccEntry[0].cramt - dramout
                                }
                            };
                    oddExtract.AddRange(newEntry);
                }
            }
            oddExtract.Distinct().ToList();


            /* ----------- Zero Credit and Debit Transactions of remaining Accounts ----------- */

            // oddDebit ids
            var idNonZero = (idExtract.AsEnumerable())
                           .Union(idOdd.AsEnumerable()).Distinct().ToList();

            
            // id with zero transactions
            var idZero = new List<string>();
            for(int i = 0; i<orgnIds.Count; i++)
            {
                if (!idNonZero.Contains(orgnIds[i]))
                {
                    idZero.Add(orgnIds[i]);
                }
            }

            for( int i=0; i<idZero.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("zero trans id is: "+idZero[i]); 
            }
            
            for (int i = 0; i < idZero.Count; i++)
            {
                if (orgnIds.Contains(idZero[i]))
                {
                    var AccEntry = (from n in COA.AsEnumerable()
                                    where (n.AccCode == idZero[i])
                                    select n).ToList();

                    var newEntry = new List<Status>() {
                                 new Status() {
                                ID = AccEntry[0].ID,
                                AccCode = AccEntry[0].AccCode,
                                Accname = AccEntry[0].Accname,
                                ParentId = AccEntry[0].ParentId,
                                Acclevel = AccEntry[0].Acclevel,
                                crcoacode = "",
                                cramt = 0,
                                drcoacode = "",
                                dramt = 0,
                                Balance = 0
                                }
                            };
                    oddExtract.AddRange(newEntry);
                }
            }
            oddExtract.Distinct().ToList();
           

            /*
            var accQuery1 = (from n in oddList.AsEnumerable()
                            where !(n.crcoacode == null && n.drcoacode == null)
                            select n).ToList();
            for (int i = 0; i < idOdd.Count; i++)
            {   
                var accQuery2 = (from v in accQuery1.AsEnumerable()
                                     where (v.crcoacode != null)
                                     orderby v.crcoacode ascending
                                     select v.crcoacode).Distinct().ToList();
                var accQueryData2 = (from v in accQuery1.AsEnumerable()
                                 where (v.crcoacode != null)
                                 orderby v.crcoacode ascending
                                 select v).ToList();

                if (accQuery2.Contains(idOdd[i]))
                {
                    var AccEntry = accQueryData2.Where(x => x.crcoacode!.Contains(idOdd[i])).ToList();
                
                    if (AccEntry != null)
                    {
                        decimal cramout = 0;
                        cramout = AccEntry.Sum(x => x.cramt);
                            //.AsEnumerable().Sum(x => x.cramt);

                        var newEntry = new List<Status>() {
                        new Status() {
                        ID= AccEntry[0].ID,
                        AccCode = AccEntry[0].AccCode,
                        Accname = AccEntry[0].Accname,
                        ParentId = AccEntry[0].ParentId,
                        Acclevel = AccEntry[0].Acclevel,
                        crcoacode = AccEntry[0].crcoacode,
                        cramt = cramout,
                        drcoacode = AccEntry[0].drcoacode,
                        dramt = AccEntry[0].dramt,
                        Balance = cramout - 0,
                        }};
                        oddExtract.AddRange(newEntry);
                    }
                }
                // Extracting one entry for all Debit transaction of one account
                var accQuery3 = (from v in accQuery1.AsEnumerable()
                                 where (v.drcoacode != null)
                                 orderby v.drcoacode ascending
                                 select v.drcoacode).Distinct().ToList();

                var accQueryData3 = (from v in accQuery1.AsEnumerable()
                                 where (v.drcoacode != null)
                                 orderby v.drcoacode ascending
                                 select v).ToList();

                if (accQuery3.Contains(idOdd[i]))
                {
                    var AccEntryDr = accQueryData3.Where(x => x.drcoacode!.Contains(idOdd[i])).ToList();

                    if (AccEntryDr != null)
                    {
                        decimal dramout = 0;
                        dramout = AccEntryDr.AsEnumerable().Sum(x => x.dramt);
                            //.AsEnumerable().Sum(x => x.dramt);

                            var newEntry = new List<Status>() {
                            new Status() {
                            ID= AccEntryDr[0].ID,
                            AccCode = AccEntryDr[0].AccCode,
                            Accname = AccEntryDr[0].Accname,
                            ParentId = AccEntryDr[0].ParentId,
                            Acclevel = AccEntryDr[0].Acclevel,
                            crcoacode = AccEntryDr[0].crcoacode,
                            cramt = AccEntryDr[0].cramt,
                            drcoacode = AccEntryDr[0].drcoacode,
                            dramt = dramout,
                            Balance = 0 - dramout,
                            }};
                            oddExtract.AddRange(newEntry);
                    }   
                } 
            }
            oddExtract.Distinct().ToList();
            System.Diagnostics.Debug.WriteLine("odd Transactions Counts" + oddExtract.Count);

            */


            System.Diagnostics.Debug.WriteLine("Started printing Odd list -----------------");
            for (int e = 0; e < oddExtract.Count; e++)
            {
                        for (int j = 0; j < 10; j++)
                        {
                            if (j == 0)
                            {
                                System.Diagnostics.Debug.WriteLine("Id is: "+oddExtract[e].ID);
                            }
                            if (j == 1)
                            {
                                System.Diagnostics.Debug.WriteLine("AccCode is: " + oddExtract[e].AccCode);
                            }
                            if (j == 2)
                            {
                                System.Diagnostics.Debug.WriteLine("AccName is: " + oddExtract[e].Accname);
                            }
                            if (j == 3)
                            {
                                System.Diagnostics.Debug.WriteLine("ParentID is: " + oddExtract[e].ParentId);
                            }
                            if (j == 4)
                            {
                                System.Diagnostics.Debug.WriteLine("AccLevel is: " + oddExtract[e].Acclevel);
                            }
                            if (j == 5)
                            {
                                System.Diagnostics.Debug.WriteLine("crcoacode is: " + oddExtract[e].crcoacode);

                            }
                            if (j == 6)
                            {
                                System.Diagnostics.Debug.WriteLine("credit Amount is: " + oddExtract[e].cramt);
                            }
                            if (j == 7)
                            {
                                System.Diagnostics.Debug.WriteLine("dbcoacode is: " + oddExtract[e].drcoacode);
                            }
                            if (j == 8)
                            {
                                System.Diagnostics.Debug.WriteLine("debit amount is: " + oddExtract[e].dramt);
                            }
                            if (j == 9)
                            {
                                System.Diagnostics.Debug.WriteLine("Balance is: " + oddExtract[e].Balance);
                            }
                        }
                    }
            System.Diagnostics.Debug.WriteLine("PRINTING ENDED -------------------");
            




            var finalList0 = new List<Status>();

            /*
            for (int i = 0; i < (CombinedTable1.Count + CombinedTable2.Count); i++)
            {
                var Fdata = new List<Status>(){
                    new Status
                    {
                    ID = 0,
                    AccCode = "",
                    Accname = "",
                    Acclevel = 0,
                    crcoacode = "",
                    cramt = 0,
                    drcoacode = "",
                    dramt = 0,
                    Balance = 0
                    }
                };
                finalList0.AddRange(Fdata);
            }

           
            for (int i = 0; i < CombinedTable1.Count; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        finalList0[i].ID = CombinedTable1[i].ID;
                    }
                    if (j == 1)
                    {
                        finalList0[i].AccCode = CombinedTable1[i].AccCode;
                    }
                    if (j == 2)
                    {
                        finalList0[i].Accname = CombinedTable1[i].Accname;
                    }
                    if (j == 3)
                    {
                        finalList0[i].Acclevel = CombinedTable1[i].Acclevel;
                    }
                    
                    if (j == 4)
                    {
                        finalList0[i].crcoacode = CombinedTable1[i].crcoacode;
                    }
                    if (j == 5)
                    {
                        finalList0[i].cramt = CombinedTable1[i].cramt;
                    }
                    
                    if (j == 6)
                    {
                        finalList0[i].drcoacode = CombinedTable2[i].drcoacode;
                    }
                    if (j == 7)
                    {
                        finalList0[i].dramt = CombinedTable2[i].dramt;
                    }
                    
                    if (j == 8)
                    {
                        finalList0[i].Balance = CombinedTable1.Count + CombinedTable2.Count;
                    }
                    
                }
            }
            */
            
            for (int i = 0; i < finalStatus1.Count+ oddExtract.Count; i++)
            {
                var Fdata = new List<Status>(){
                    new Status
                    {
                    ID = 0,
                    AccCode = "",
                    Accname = "",
                    ParentId =0,
                    Acclevel = 0,
                    crcoacode = "",
                    cramt = 0,
                    drcoacode = "",
                    dramt = 0,
                    Balance = 0
                    }
                };
                finalList0.AddRange(Fdata);
            }

            System.Diagnostics.Debug.WriteLine("final data cout" + finalStatus1.Count);
            for (int i=0; i<finalStatus1.Count;i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                    {
                        finalList0[i].ID = finalStatus1[i].ID;
                    }
                    if (j ==1)
                    {
                        finalList0[i].AccCode = finalStatus1[i].AccCode;
                    }
                    if (j == 2)
                    {
                        finalList0[i].Accname = finalStatus1[i].Accname;
                    }
                    if (j == 3)
                    {
                        finalList0[i].ParentId = finalStatus1[i].ParentId;
                    }
                    if (j == 4)
                    {
                        finalList0[i].Acclevel = finalStatus1[i].Acclevel;
                    }
                    if (j == 5)
                    {
                        finalList0[i].crcoacode = finalStatus1[i].crcoacode;
                    }
                    if (j == 6)
                    {
                        finalList0[i].cramt = finalStatus1[i].cramt;
                    }
                    if (j == 7)
                    {
                        finalList0[i].drcoacode = finalStatus1[i].drcoacode;
                    }
                    if (j == 8)
                    {
                        finalList0[i].dramt = finalStatus1[i].dramt;
                    }
                    if (j == 9)
                    {
                        finalList0[i].Balance = finalStatus1[i].Balance;
                    }
                  
                }
            }
           
            var start = finalStatus1.Count;
            var limit = finalStatus1.Count + oddExtract.Count;
            System.Diagnostics.Debug.WriteLine("odd start " + start + "odds limit " + limit);

            int m = -1;
            for (int i = start; i < limit; i++)
            {
                m++;
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                    {
                        finalList0[i].ID = oddExtract[m].ID;
                    }
                    if (j == 1)
                    {
                        finalList0[i].AccCode = oddExtract[m].AccCode;
                    }
                    if (j == 2)
                    {
                        finalList0[i].Accname = oddExtract[m].Accname;
                    }
                    if (j == 3)
                    {
                        finalList0[i].ParentId = oddExtract[m].ParentId;
                    }
                    if (j == 4)
                    {
                        finalList0[i].Acclevel = oddExtract[m].Acclevel;
                    }
                    if (j == 5)
                    {
                        finalList0[i].crcoacode = oddExtract[m].crcoacode;
                    }
                    if (j == 6)
                    {
                        finalList0[i].cramt = oddExtract[m].cramt;
                    }
                    if (j == 7)
                    {
                        finalList0[i].drcoacode = oddExtract[m].drcoacode;
                    }
                    if (j == 8)
                    {
                        finalList0[i].dramt = oddExtract[m].dramt;
                    }
                    if (j == 9)
                    {
                        finalList0[i].Balance = oddExtract[m].Balance;
                    }

                }
            }
            // sorting according to parentID
            var SrtFinal = (from i in finalList0.AsEnumerable()
                            orderby i.ParentId ascending
                            select i
                            ).ToList();


            // Transforming to tree view:
            var SrtFinals = (from i in finalList0.AsEnumerable()
                            orderby i.Acclevel ascending
                            group i by i.ParentId into newGroup
                            select newGroup
                            ).ToList();

            // final data construction for tree view
            var finalTree = new List<CombinedAccount.TreeList>();
            int v = -1;
            
            
            foreach (var i in SrtFinals)
            { var newlist = new List<CombinedAccount.TreeList>()
            {
                new CombinedAccount.TreeList() {
                Header = new List<Status>(),
                Items = new List<Status>()
                }
            }
                    ;
                finalTree.AddRange(newlist);
                v++;
                var Fdata = new List<Status>(){
                    new Status
                    {
                    ID = 0,
                    AccCode = "",
                    Accname = "",
                    ParentId =0,
                    Acclevel = 0,
                    crcoacode = "",
                    cramt = 0,
                    drcoacode = "",
                    dramt = 0,
                    Balance = 0
                    }
                };
                
                finalTree[v].Header.AddRange(Fdata);
                /*
                foreach (var z in i)
                {
                    
                    var Fdata1 = new List<Status>(){
                    new Status
                    {
                    ID = 0,
                    AccCode = "",
                    Accname = "",
                    ParentId =0,
                    Acclevel = 0,
                    crcoacode = "",
                    cramt = 0,
                    drcoacode = "",
                    dramt = 0,
                    Balance = 0
                    }
                };
                    
                    finalTree[v].Items.AddRange(Fdata1);
                }
                */
            }

            int x = -1;
            int b = -1;
            foreach (var it in SrtFinals)
            {
                x++;
                System.Diagnostics.Debug.WriteLine($"key {it.Key}");
                var totalCr = it.AsEnumerable().Sum(x => x.cramt);
                var totalDr = it.Sum(x => x.dramt);
                //dramout = AccEntry.AsEnumerable().AsEnumerable().Sum(x => x.dramt);
                b++;
                finalTree[x].Header = new List<Status> {
                        new Status () {
                            ID = it.First().ID,
                            AccCode = it.First().AccCode,
                            Accname = it.First().Accname,
                            Acclevel = it.First().Acclevel,
                            ParentId = it.First().ParentId,
                            cramt = totalCr,
                            dramt = totalDr,
                            Balance = totalCr - totalDr,
                           
                        }
                };
                System.Diagnostics.Debug.WriteLine($"Data inserted header{b}");

                int f = -1;
                foreach (var i in it)
                {
                    f++;
                    var newItem = new List<Status> {
                        new Status () {
                            ID = i.ID,
                            AccCode = i.AccCode,
                            Accname = i.Accname,
                            Acclevel = i.Acclevel,
                            ParentId = i.ParentId,
                            cramt = i.cramt,
                            dramt = i.dramt,
                            Balance = i.Balance,
                        }
                    };
                    finalTree[x].Items.AddRange(newItem);
                    System.Diagnostics.Debug.WriteLine($"Data items inserted {f} times");
                }
            }

            

            var CombinedTable = (from acr in CombinedTable1.AsEnumerable()
                                 join adr in CombinedTable2.AsEnumerable()
                                 on acr.AccCode equals adr.drcoacode
                                 orderby acr.AccCode
                                 select new
                                 {
                                     AccCode = acr.AccCode,
                                     Accname = acr.Accname,
                                     ParentId = acr.ParentId,
                                     Level = acr.Acclevel,
                                     crcoacode = acr.crcoacode,
                                     cramt = acr.cramt,
                                     drcoacode = adr.drcoacode,
                                     dramt = adr.dramt

                                 }).ToList();



            /*
            static decimal Add(decimal[] a)
            {
                decimal Result = 0;
                for (int i=0; i<a.Length; i++)
                {
                    Result = Result + a[i];
                }
                return Result;
            };
            */


            /*
            var Balance1 = (CombinedTable.GroupBy(x => x.cramt.AsQueryable().Sum(),
                x => x.crcoacode,
                 (a) => new
                 {
                     AccCode = a.AccCode,
                     Accname = a.Accname,
                     Level = a.Acclevel,
                     crcoacode = a.crcoacode,
                     cramt = a.cramt,
                     drcoacode = a.drcoacode,
                     dramt = a.dramt

                 }

             ).ToList();
            */
            /*
         
            var balance = "";
            var level = "";

            */
            //ViewBag.Final = finalList0;
            //ViewData["FinalStat"] = CombinedTable1;

           

            var AccountStatusVM = new CombinedAccount
            {
                COA = await COA.ToListAsync(),
                Voucher = await Voucher.ToListAsync(),
                Status = SrtFinal,
                treeList = finalTree
            };

            return View(AccountStatusVM);

        }
    }
}
