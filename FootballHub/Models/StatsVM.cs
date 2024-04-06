using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FootballHub.Models
{
    public class StatsVM
    {
        [ValidateNever]
        public Player Player { get; set; }
        public List<Stats> Stats { get; set; }
    }
}
