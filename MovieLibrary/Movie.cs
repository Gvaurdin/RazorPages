using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Вы не заполнили поле \"Название\"")]
        [StringLength(maximumLength: 60, MinimumLength =2)]
        public required string Title { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле \"Ссылка на фильм\"")]
        public required string URL { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Описание фильма\"")]
        [StringLength(maximumLength: 500, MinimumLength = 10)]
        public required string Description { get; set; }
        public required TimeSpan Duration { get; set; } = default(TimeSpan);
    }
}
