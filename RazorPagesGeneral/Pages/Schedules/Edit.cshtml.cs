using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Pages.Schedules
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesGeneral.Data.MovieContext _context;

        public EditModel(RazorPagesGeneral.Data.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shedule Shedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shedule =  await _context.Shedules.FirstOrDefaultAsync(m => m.Id == id);
            if (shedule == null)
            {
                return NotFound();
            }
            Shedule = shedule;
           ViewData["HallCinemaId"] = new SelectList(_context.HallCinemas, "Id", "Id");
           ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SheduleExists(Shedule.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SheduleExists(int id)
        {
            return _context.Shedules.Any(e => e.Id == id);
        }
    }
}
