using MovieLibrary;

namespace RazorPagesGeneral.Model
{
    public class FormattedShedule
    {
        public Dictionary<Movie,List<Shedule>>? ShedulesByMovie { get; set; }
    }
}
