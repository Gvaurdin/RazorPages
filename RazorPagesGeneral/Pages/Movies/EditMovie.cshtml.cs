using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieLibrary;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;
using RazorPagesGeneral.Pages.Services.Interfaces;
using RazorPagesGeneral.ViewModel;

namespace RazorPagesGeneral.Pages.Movies
{
    public class EditMovieModel(MovieContext movieContext, IPhotoService photoService) : PageModel
    {
        [BindProperty]
        public MovieViewModel MovieViewModel { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movie = await movieContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            MovieViewModel = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                URL = null
            };

            return Page();
            
        }



        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var movie = await movieContext.Movies.FirstOrDefaultAsync(m => m.Id == MovieViewModel.Id);

            if(MovieViewModel.URL is not null)
            {
                await photoService.DeletePhotoAsync(movie.URL);
                var resultAddPhoto = await photoService.AddPhotoAsync(MovieViewModel.URL);
                movie.URL = resultAddPhoto.Url.ToString();
            }

            movie.Title = MovieViewModel.Title;
            movie.Description = MovieViewModel.Description;
            movie.Duration = MovieViewModel.Duration;

            await movieContext.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
