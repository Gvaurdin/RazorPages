using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Pages.HallCinemas
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGeneral.Data.MovieContext _context;

        public IndexModel(RazorPagesGeneral.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<HallCinema> HallCinema { get;set; } = default!;

        public async Task OnGetAsync()
        {
            HallCinema = await _context.HallCinemas.ToListAsync();
        }
    }
}
