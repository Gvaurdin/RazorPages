using MovieLibrary;

namespace RazorPagesGeneral.Model
{
    public class Shedule
    {
        public required int Id { get; set; }
        public required DateTime StartFilm { get; set; }
        public required DateTime EndFilm { get; set; }
        public int MovieId { get; set; }
        public int HallCinemaId {  get; set; }
        public Movie? Movie { get; set; }
        public HallCinema? HallCinema { get; set; }

        public required int Cost { get; set; }
    }
}
