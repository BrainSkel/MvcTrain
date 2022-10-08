using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTrains.Data;
using MvcTrains.Models;

namespace MvcTrains.Controllers
{
    public class TrainsController : Controller
    {
        private readonly MvcTrainsContext _context;

        public TrainsController(MvcTrainsContext context)
        {
            _context = context;
        }

        // GET: Trains
        public async Task<IActionResult> Index(int trainStops, string searchString)
        {
            IQueryable<int> stopQuery = from m in _context.Train
                                           orderby m.Stops
                                           select m.Stops;

            var trains = from m in _context.Train
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                trains = trains.Where(s => s.Destination.Contains(searchString));
            }

            if (trainStops > 0)
            {
                trains = trains.Where(x => x.Stops == trainStops);
            }

            var trainStopsVM = new TrainStopViewModel
            {
                Stops = new SelectList(await stopQuery.Distinct().ToListAsync()),
                Trains = await trains.ToListAsync()
            };

            return View(trainStopsVM);
        }

        // GET: Trains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Train == null)
            {
                return NotFound();
            }

            var train = await _context.Train
                .FirstOrDefaultAsync(m => m.Id == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // GET: Trains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Destination, Speed,Stops,WifiPassword")] Train train)
        {
            if (ModelState.IsValid)
            {
                _context.Add(train);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(train);
        }

        // GET: Trains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Train == null)
            {
                return NotFound();
            }

            var train = await _context.Train.FindAsync(id);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // POST: Trains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Destination,Speed,Stops,WifiPassword")] Train train)
        {
            if (id != train.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(train);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainExists(train.Id))
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
            return View(train);
        }

        // GET: Trains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Train == null)
            {
                return NotFound();
            }

            var train = await _context.Train
                .FirstOrDefaultAsync(m => m.Id == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // POST: Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Train == null)
            {
                return Problem("Entity set 'MvcTrainsContext.Train'  is null.");
            }
            var train = await _context.Train.FindAsync(id);
            if (train != null)
            {
                _context.Train.Remove(train);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainExists(int id)
        {
          return _context.Train.Any(e => e.Id == id);
        }
    }
}
