using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;
using RazorPagesGeneral.Pages.Services.Interfaces;
using RazorPagesGeneral.ViewModel;

namespace RazorPagesGeneral.Pages.Movies
{
    public class CreateMovieModel(MovieContext movieContext, IPhotoService photoService) : PageModel
    {
        public void OnGet()
        {
        }

        //public IActionResult OnPost()
        //{
        //    var lastMovie = MovieStorage.movies.Last();
        //    Movie!.Id = lastMovie.Id;
        //    Movie.Id++;
        //    if (Movie is null || !ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    MovieStorage.movies.Add(Movie);
        //    return RedirectToPage("./Index");
        //}

        [BindProperty]
        public MovieViewModel MovieViewModel { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (MovieViewModel.URL is null || !ModelState.IsValid)
            {
                return Page();
            }

            var resultAddPhoto = await photoService.AddPhotoAsync(MovieViewModel.URL);


            var movie = new Movie
            {
                Title = MovieViewModel.Title,
                Description = MovieViewModel.Description,
                Duration = default(TimeSpan),
                URL = resultAddPhoto.Url.ToString()
            };
            await movieContext.Movies.AddAsync(movie);
            await movieContext.SaveChangesAsync();



            return RedirectToPage("./index");
        }
    }
}
