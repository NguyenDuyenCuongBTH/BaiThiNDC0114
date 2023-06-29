using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiNDC.Models;

namespace BaiThiNDC.Controllers
{
    public class NDCCau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public NDCCau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NDCCau3
        public async Task<IActionResult> Index()
        {
              return _context.NDCCau3 != null ? 
                          View(await _context.NDCCau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NDCCau3'  is null.");
        }

        // GET: NDCCau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NDCCau3 == null)
            {
                return NotFound();
            }

            var nDCCau3 = await _context.NDCCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (nDCCau3 == null)
            {
                return NotFound();
            }

            return View(nDCCau3);
        }

        // GET: NDCCau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NDCCau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,Sdt")] NDCCau3 nDCCau3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nDCCau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nDCCau3);
        }

        // GET: NDCCau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NDCCau3 == null)
            {
                return NotFound();
            }

            var nDCCau3 = await _context.NDCCau3.FindAsync(id);
            if (nDCCau3 == null)
            {
                return NotFound();
            }
            return View(nDCCau3);
        }

        // POST: NDCCau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName,Sdt")] NDCCau3 nDCCau3)
        {
            if (id != nDCCau3.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nDCCau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NDCCau3Exists(nDCCau3.StudentID))
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
            return View(nDCCau3);
        }

        // GET: NDCCau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NDCCau3 == null)
            {
                return NotFound();
            }

            var nDCCau3 = await _context.NDCCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (nDCCau3 == null)
            {
                return NotFound();
            }

            return View(nDCCau3);
        }

        // POST: NDCCau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NDCCau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NDCCau3'  is null.");
            }
            var nDCCau3 = await _context.NDCCau3.FindAsync(id);
            if (nDCCau3 != null)
            {
                _context.NDCCau3.Remove(nDCCau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NDCCau3Exists(string id)
        {
          return (_context.NDCCau3?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
