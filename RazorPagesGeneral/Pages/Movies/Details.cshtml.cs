using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieLibrary;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Pages.Movies
{
    public class DetailsModel(MovieContext movieContext) : PageModel
    {
        public Shedule? Shedule { get; set; }
        public async Task OnGetAsync(int id)
        {
            Shedule = await movieContext.Shedules.Include(shedule => shedule.Movie).FirstAsync(shedule => shedule.Id == id);
        }
    }
}
