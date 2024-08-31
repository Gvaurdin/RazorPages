using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Pages.Schedules
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesGeneral.Data.MovieContext _context;

        public CreateModel(RazorPagesGeneral.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HallCinemaId"] = new SelectList(_context.HallCinemas, "Id", "Id");
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Shedule Shedule { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shedules.Add(Shedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
