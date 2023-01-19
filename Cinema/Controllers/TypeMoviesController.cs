using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;
using Cinema.Helper;

namespace Cinema.Controllers
{
    public class TypeMoviesController : Controller
    {
        private readonly DataContext _context;

        public TypeMoviesController(DataContext context)
        {
            _context = context;
        }

        // GET: TypeMovies
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TypeMovies.Include(t => t.Movie);
            return View(await dataContext.ToListAsync());
        }

        // GET: TypeMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeMovies == null)
            {
                return NotFound();
            }

            var typeMovie = await _context.TypeMovies
                .Include(t => t.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeMovie == null)
            {
                return NotFound();
            }

            return View(typeMovie);
        }

        // GET: TypeMovies/Create
        public IActionResult Create()
        {
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Id");
            return View();
        }

        // POST: TypeMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,MovieID")] TypeMovieDto typeMovieDto)
        {
            TypeMovie type = new TypeMovie();
            type.MovieID = typeMovieDto.MovieID;
            type.Type=typeMovieDto.Type;
            if (ModelState.IsValid)
            {
                _context.Add(type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Id", type.MovieID);
            return View(type);
        }

        // GET: TypeMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeMovies == null)
            {
                return NotFound();
            }

            var typeMovie = await _context.TypeMovies.FindAsync(id);
            if (typeMovie == null)
            {
                return NotFound();
            }
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Id", typeMovie.MovieID);
            return View(typeMovie);
        }

        // POST: TypeMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,MovieID")] TypeMovieDto typeMovieDto)
        {
            TypeMovie type = new TypeMovie();
            type.MovieID = typeMovieDto.MovieID;
            type.Type = typeMovieDto.Type;
            type.Id = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeMovieExists(type.Id))
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
            ViewData["MovieID"] = new SelectList(_context.Movies, "Id", "Id", type.MovieID);
            return View(type);
        }

        // GET: TypeMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeMovies == null)
            {
                return NotFound();
            }

            var typeMovie = await _context.TypeMovies
                .Include(t => t.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeMovie == null)
            {
                return NotFound();
            }

            return View(typeMovie);
        }

        // POST: TypeMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeMovies == null)
            {
                return Problem("Entity set 'DataContext.TypeMovies'  is null.");
            }
            var typeMovie = await _context.TypeMovies.FindAsync(id);
            if (typeMovie != null)
            {
                _context.TypeMovies.Remove(typeMovie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeMovieExists(int id)
        {
          return _context.TypeMovies.Any(e => e.Id == id);
        }
    }
}
