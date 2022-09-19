using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Account.Data;
using Account.Models;

namespace Account.Controllers
{
    public class COAsController : Controller
    {
        private readonly AccountContext _context;

        public COAsController(AccountContext context)
        {
            _context = context;
        }

        // GET: COAs
        public async Task<IActionResult> Index()
        {
              return _context.COA != null ? 
                          View(await _context.COA.ToListAsync()) :
                          Problem("Entity set 'AccountContext.COA'  is null.");
        }

        // GET: COAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.COA == null)
            {
                return NotFound();
            }

            var cOA = await _context.COA
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cOA == null)
            {
                return NotFound();
            }

            return View(cOA);
        }

        // GET: COAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: COAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AccCode,Accname,ParentId,Acclevel")] COA cOA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cOA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cOA);
        }

        // GET: COAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.COA == null)
            {
                return NotFound();
            }

            var cOA = await _context.COA.FindAsync(id);
            if (cOA == null)
            {
                return NotFound();
            }
            return View(cOA);
        }

        // POST: COAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AccCode,Accname,ParentId,Acclevel")] COA cOA)
        {
            if (id != cOA.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cOA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!COAExists(cOA.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cOA);
        }

        // GET: COAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.COA == null)
            {
                return NotFound();
            }

            var cOA = await _context.COA
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cOA == null)
            {
                return NotFound();
            }

            return View(cOA);
        }

        // POST: COAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.COA == null)
            {
                return Problem("Entity set 'AccountContext.COA'  is null.");
            }
            var cOA = await _context.COA.FindAsync(id);
            if (cOA != null)
            {
                _context.COA.Remove(cOA);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool COAExists(int id)
        {
          return (_context.COA?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
