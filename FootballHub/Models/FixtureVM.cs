using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballHub.Models
{
    public class FixtureVM
    {
        public Fixture Fixture { get; set; }
        [ValidateNever]
        public List<SelectListItem> Opponents { get; set; }
        [ValidateNever]
        public List<SelectListItem> MatchTypes { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem(){Text = "Home", Value = "Home"},
            new SelectListItem() {Text = "Away", Value = "Away"}
        };
    }
}
