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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGeneral.Data.MovieContext _context;

        public IndexModel(RazorPagesGeneral.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Shedule> Shedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Shedule = await _context.Shedules
                .Include(s => s.HallCinema)
                .Include(s => s.Movie).ToListAsync();
        }
    }
}
