using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballHub.Models
{
    public class Stats
    {
        public int Id { get; set; }
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public string Season { get; set; }
        public int Apps { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        [ValidateNever]
        public Player Player { get; set; }
    }
}
