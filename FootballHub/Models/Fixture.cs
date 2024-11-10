using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballHub.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        [ForeignKey("Opponent")]
        public int OpponentId { get; set; }
        [ValidateNever]
        public Opponent Opponent { get; set; }
        public DateTime MatchTime { get; set; }
      
        public string MatchType { get; set; }
        public string Venue { get; set; }
    }
}
