using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieLibrary;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Pages.Movies
{
    public class DeleteMovieModel(MovieContext movieContext) : PageModel
    {
        public Movie movie { get; set; }
        public async Task OnGetAsync(int id)
        {
            movie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
            //movie = MovieStorage.movies.Find(movie => movie.Id == id);

        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var movie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
            movieContext.Movies.Remove(movie);
            await movieContext.SaveChangesAsync();
            //MovieStorage.movies.Remove(movie);

            return RedirectToPage("./Index");
        }
    }
}
