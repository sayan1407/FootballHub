using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FootballHub.Models
{
    public class RegisterVM
    {
        [Remote(controller:"Account",action: "CheckValidUserName")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Remote(controller: "Account", action: "CheckValidEmail")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }
    }
}
