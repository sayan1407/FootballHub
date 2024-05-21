using FootballHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FootballHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    Email = registerVM.Email,
                    UserName = registerVM.UserName,
                    

                };
                
                var result = await _userManager.CreateAsync(user,registerVM.Password);
               
                if(result.Succeeded)
                {
                  await  _signInManager.SignInAsync(user, isPersistent: false);
                   return RedirectToAction("Index","Home");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM,string? ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = loginVM.UserName,
                };
               var result =  await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
                if(result.Succeeded)
                {
                    //Temporary code to create superuser
                    //await _roleManager.CreateAsync(new IdentityRole()
                    //{
                    //    Name = "SUPERUSER"
                    //});
                    //var userInDb = _userManager.Users.Single(u => u.UserName == loginVM.UserName);
                    //var r = await _userManager.AddToRoleAsync(userInDb, "SUPERUSER");
                    if (!string.IsNullOrEmpty(ReturnUrl))
                        return LocalRedirect(ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }
                
            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View();
        }
        public IActionResult CheckValidUserName(string UserName)
        {
            var users = _userManager.Users;
            if (users.Count(u => u.UserName == UserName) > 0)
                return Json(data: "User Name is already exist");
            return Json(data: true);
        }
        public IActionResult CheckValidEmail(string Email)
        {
            var users = _userManager.Users;
            if (users.Count(u => u.Email == Email) > 0)
                return Json(data: "User Name is already exist");
            return Json(data: true);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
