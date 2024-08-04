using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales_Web.Models;

namespace Sales_Web.Controllers
{
    public class SalesProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesProducts.ToListAsync());
        }

        // GET: SalesProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesProduct = await _context.SalesProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesProduct == null)
            {
                return NotFound();
            }

            return View(salesProduct);
        }

        // GET: SalesProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalesId,ProductsId")] SalesProduct salesProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesProduct);
        }

        // GET: SalesProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesProduct = await _context.SalesProducts.FindAsync(id);
            if (salesProduct == null)
            {
                return NotFound();
            }
            return View(salesProduct);
        }

        // POST: SalesProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalesId,ProductsId")] SalesProduct salesProduct)
        {
            if (id != salesProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesProductExists(salesProduct.Id))
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
            return View(salesProduct);
        }

        // GET: SalesProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesProduct = await _context.SalesProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesProduct == null)
            {
                return NotFound();
            }

            return View(salesProduct);
        }

        // POST: SalesProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesProduct = await _context.SalesProducts.FindAsync(id);
            if (salesProduct != null)
            {
                _context.SalesProducts.Remove(salesProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesProductExists(int id)
        {
            return _context.SalesProducts.Any(e => e.Id == id);
        }
    }
}
