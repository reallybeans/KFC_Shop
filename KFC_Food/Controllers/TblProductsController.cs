using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KFC_Food.Data;
using KFC_Food.Models;
using Microsoft.AspNetCore.Http;

namespace KFC_Food.Controllers
{
    public class TblProductsController : Controller
    {
        private readonly KFC_DATAContext _context;

        public TblProductsController(KFC_DATAContext context)
        {
            _context = context;
        }

        // GET: TblProducts
        public async Task<IActionResult> Index()
        {
            try
            {
                string searchValue = TempData["SearchValue"].ToString();
                var kFC_DATAContext1 = _context.TblProducts.Where(s => s.ProductName.Contains(searchValue)).Include(t => t.Category);
                return View(await kFC_DATAContext1.ToListAsync());
            }
            catch { }
            var kFC_DATAContext = _context.TblProducts.Include(t => t.Category);
            return View(await kFC_DATAContext.ToListAsync());
        }

        // GET: TblProducts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }

        // GET: TblProducts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: TblProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Price,Description,Quantity,ImgSrc,CategoryId")] TblProduct tblProduct)
        {
            ViewData["CategoryId"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryId", tblProduct.CategoryId);
            if (_context.TblProducts.Find(tblProduct.ProductId) != null)
            {
                return RedirectToAction(nameof(Error));
            }
            if (ModelState.IsValid)
            {
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }    
            return View(tblProduct);
        }

        // GET: TblProducts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryId", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // POST: TblProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductId,ProductName,Price,Description,Quantity,ImgSrc,CategoryId")] TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryId", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // GET: TblProducts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: TblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblProduct = await _context.TblProducts.FindAsync(id);
            _context.TblProducts.Remove(tblProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(string id)
        {
            return _context.TblProducts.Any(e => e.ProductId == id);
        }

        public IActionResult Search(IFormCollection form )
        {
            string searchValue = form["searchValue"];
            if (searchValue.Length > 0)
            {
                TempData["SearchValue"] = searchValue;
                return RedirectToAction("Index", "TblProducts");
            }
            return RedirectToAction("Index", "TblProducts");

        }
    }
}
