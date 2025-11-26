using EZTix.Data;
using EZTix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EZTix.Controllers
{
    public class ShowsController : Controller
    {
        private readonly EZTixContext _context;

        public ShowsController(EZTixContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var eZTixContext = _context.Show.Include(s => s.Category).Include(s => s.Venue);
            return View(await eZTixContext.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.Category)
                .Include(s => s.Venue)
                .Include(s => s.Purchases)
                .FirstOrDefaultAsync(m => m.ShowID == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName");
            ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowID,Title,Description,ShowTime,Owner,Created,CategoryId,VenueId,FileName,FormFile")] Show show)
        {

            show.Created = DateTime.Now;
            {
                if (ModelState.IsValid)
                {
                    
                    //
                    // Step 1: save the file (optionally)
                    //
                    if (show.FormFile != null)
                    {
                        // Create a unique filename using a Guid          
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(show.FormFile.FileName); // f81d4fae-7dec-11d0-a765-00a0c91e6bf6.jpg

                        // Initialize the filename in photo record
                        show.FileName = filename;

                        // Get the file path to save the file. Use Path.Combine to handle diffferent OS
                        string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                        // Save file
                        using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Create))
                        {
                            await show.FormFile.CopyToAsync(fileStream);
                        }
                        _context.Add(show);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index), "Home"); // Home index page
                    }
                  
                }
                ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", show.CategoryId);
                ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName", show.VenueId);
                return View(show);
            }
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", show.CategoryId);
            ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName", show.VenueId);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowID,Title,Description,ShowTime,Owner,Created,CategoryId,VenueId")] Show show)
        {
            if (id != show.ShowID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowID))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", show.CategoryId);
            ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "VenueName", show.VenueId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.Category)
                .Include(s => s.Venue)
                .FirstOrDefaultAsync(m => m.ShowID == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Show.FindAsync(id);
            if (show != null)
            {
                _context.Show.Remove(show);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.ShowID == id);
        }

    }
}
