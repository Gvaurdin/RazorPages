using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieLibrary;
using NuGet.Packaging;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesGeneral.Pages.Movies
{
    public class IndexModel(MovieContext movieContext, FormattedShedule formattedShedule) : PageModel
    {
        public Dictionary<Movie, List<Shedule>>? ShedulesByMovie { get; set; }
        public string? MaxDateMovie { get; set; }
        public string? MinDateMovie { get; set; }
        public string? SelectedDateMovie { get; set; }

        private const string FormatDate = "yyyy-MM-dd";
        private const string FormatFilteredDate = "{0:yyyy-MM-ddTHH:mm}";
        public async Task OnGetAsync()
        {
            ShedulesByMovie = await movieContext.Shedules!
                .Include(schedule => schedule.Movie)
                .Where(schedule => schedule.StartFilm.Date == DateTime.Now.Date)
                .Where(schedule => schedule.Movie != null)
                .GroupBy(schedule => schedule.Movie)
                .ToDictionaryAsync(group => group.Key!, group => group.Where(s => s != null).ToList());
            formattedShedule.ShedulesByMovie = ShedulesByMovie;

            if (await movieContext.Shedules!.AnyAsync())
            {
                var maxDateMovie = await movieContext.Shedules!.MaxAsync(movie => movie.StartFilm);
                MaxDateMovie = maxDateMovie.ToString(FormatDate);
            }
            else
            {

                MaxDateMovie = DateTime.Now.ToString(FormatDate);
            }

            SelectedDateMovie = DateTime.Now.ToString(FormatDate);
            MinDateMovie = DateTime.Now.ToString(FormatDate);

        }

        [BindProperty(SupportsGet = true)]
        public string? SearchTitleMovie { get; set; }

        [BindProperty(SupportsGet = true), DisplayFormat(DataFormatString = FormatFilteredDate, ApplyFormatInEditMode = true)]
        public DateTime? SearchDateMovie { get; set; }
        public async Task OnPostAsync()
        {
            IEnumerable<Shedule>? filteredShedule = movieContext.Shedules!.Include(shedule => shedule.Movie).ToList();

            if (SearchTitleMovie is not null)
            {

                filteredShedule = filteredShedule.Where(shedule => shedule.Movie!.Title.Contains(SearchTitleMovie));
            }

            if (SearchDateMovie is not null)
            {
                filteredShedule = filteredShedule.Where(shedule => shedule.StartFilm.Date == SearchDateMovie.Value.Date);
            }


            if (filteredShedule.Any())
            {
                ShedulesByMovie = filteredShedule
                    .Where(shedule => shedule.StartFilm.Date >= DateTime.Now.Date)
                    .GroupBy(shedule => shedule.Movie)
                    .ToDictionary(group => group.Key!, group => group.ToList());
            }

            var maxDateMovie = await movieContext.Shedules!.MaxAsync(movie => movie.StartFilm);

            MinDateMovie = DateTime.Now.ToString(FormatDate);
            MaxDateMovie = maxDateMovie.ToString(FormatDate);
        }
    }
}
