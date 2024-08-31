namespace RazorPagesGeneral.ViewModel
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required IFormFile? URL { get; set; }
        public required string Description { get; set; }
        public required TimeSpan Duration { get; set; }
    }
}
