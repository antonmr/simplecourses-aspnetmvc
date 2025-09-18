using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleCourses.Data;
using SimpleCourses.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCourses.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Contents
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Contents.ToListAsync());
        //}

        // GET: Admin/Contents/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var content = await _context.Contents
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (content == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(content);
        //}

        // GET: Admin/Contents/Create
        public IActionResult Create(int categoryItemId, int categoryId)
        {
            var content = new Content { CatItemId = categoryItemId, CategoryId = categoryId };
            return View(content);
        }

        // POST: Admin/Contents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,HTMLContent,VideoLink,CatItemId,CategoryId")] Content content)
        {
            if (ModelState.IsValid)
            {
                content.CategoryItem = _context.CategoryItems.Find(content.CatItemId);
                _context.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "CategoryItems", new { categoryId = content.CategoryId });
            }
            return View(content);
        }

        // GET: Admin/Contents/Edit/5
        public async Task<IActionResult> Edit(int categoryItemId, int categoryId)
        {
            if (categoryItemId == 0)
            {
                return NotFound();
            }

            var content = await _context.Contents.SingleOrDefaultAsync(i => i.CategoryItem.Id == categoryItemId);
            content.CategoryId = categoryId;

            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // POST: Admin/Contents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,HTMLContent,VideoLink,CatItemId,CategoryId")] Content content)
        {
            if (id != content.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "CategoryItems", new { categoryId = content.CategoryId, categoryItemId = content.CatItemId });
            }
            return View(content);
        }

        // GET: Admin/Contents/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var content = await _context.Contents
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (content == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(content);
        //}

        // POST: Admin/Contents/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var content = await _context.Contents.FindAsync(id);
        //    if (content != null)
        //    {
        //        _context.Contents.Remove(content);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ContentExists(int id)
        {
            return _context.Contents.Any(e => e.Id == id);
        }
    }
}
