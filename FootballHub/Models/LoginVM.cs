using System.ComponentModel.DataAnnotations;

namespace FootballHub.Models
{
    public class LoginVM
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
