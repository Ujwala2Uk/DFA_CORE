using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DFA_CORE.Models;
using NToastNotify;

namespace DFA_CORE.Controllers
{
    public class TordersController : Controller
    {
        private readonly TE_Core_MVCContext _context;
        private readonly ILogger<TordersController> _logger;
        private readonly IToastNotification _toastNotification;
        public TordersController(ILogger<TordersController> logger, IToastNotification toastNotification, TE_Core_MVCContext context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _context = context;

        }

        // GET: Torders
        public async Task<IActionResult> Index()
        {
              return View(await _context.Torders.ToListAsync());
        }

        // GET: Torders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Torders == null)
            {
                return NotFound();
            }

            var torder = await _context.Torders
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (torder == null)
            {
                return NotFound();
            }

            return View(torder);
        }

        // GET: Torders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Torders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Oid,Oname,Oitem,Oquant")] Torder torder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torder);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Order Added successfully");

                return RedirectToAction(nameof(Index));
            }
            return View(torder);
        }

        // GET: Torders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Torders == null)
            {
                return NotFound();
            }

            var torder = await _context.Torders.FindAsync(id);
            if (torder == null)
            {
                return NotFound();
            }
            return View(torder);
        }

        // POST: Torders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Oid,Oname,Oitem,Oquant")] Torder torder)
        {
            if (id != torder.Oid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torder);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddWarningToastMessage("Order updated successfully");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorderExists(torder.Oid))
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
            return View(torder);
        }

        // GET: Torders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Torders == null)
            {
                return NotFound();
            }

            var torder = await _context.Torders
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (torder == null)
            {
                return NotFound();
            }

            return View(torder);
        }

        // POST: Torders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Torders == null)
            {
                return Problem("Entity set 'TE_Core_MVCContext.Torders'  is null.");
            }
            var torder = await _context.Torders.FindAsync(id);
            if (torder != null)
            {
                _context.Torders.Remove(torder);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddErrorToastMessage("Order deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool TorderExists(int id)
        {
          return _context.Torders.Any(e => e.Oid == id);
        }
    }
}
