using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Pages.Schedules
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesGeneral.Data.MovieContext _context;

        public DeleteModel(RazorPagesGeneral.Data.MovieContext context)
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

            var shedule = await _context.Shedules.FirstOrDefaultAsync(m => m.Id == id);

            if (shedule == null)
            {
                return NotFound();
            }
            else
            {
                Shedule = shedule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shedule = await _context.Shedules.FindAsync(id);
            if (shedule != null)
            {
                Shedule = shedule;
                _context.Shedules.Remove(Shedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
