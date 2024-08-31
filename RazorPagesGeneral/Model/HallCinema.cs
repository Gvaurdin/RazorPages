using System.ComponentModel.DataAnnotations;

namespace RazorPagesGeneral.Model
{
    public class HallCinema
    {
        public int Id { get; set; }
        public required int NumberHall { get; set; }
        public required int CountRows { get; set; }
        public required int CountSeats { get; set; }
    }
}
