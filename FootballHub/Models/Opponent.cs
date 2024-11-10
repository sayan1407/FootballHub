using System.ComponentModel.DataAnnotations;

namespace FootballHub.Models
{
    public class Opponent
    {
        public int Id { get; set; }
        [Display(Name = "Club Name")]
        public string ClubName { get; set; }
        public string? Logo { get; set; }
    }
}
