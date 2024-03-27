using Lab3_MVC.Models;
using Lab3_MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Lab3_MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();// show form user Data (email , pass , name , age )
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Password = model.Password,
                    Email = model.Email

                };


                ITIContext db = new ITIContext();
                db.Users.Add(user);
                db.SaveChanges();
                var role = db.Roles.FirstOrDefault(a => a.Name == "Students");
                user.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("login");
            }


            return View(model); // add user in data base 
        }
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View(); // show form (email , pass)
        }
        [HttpPost]
        // using view model to get from el model 2 properties only  (email , pass)
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // check data base if this data exist add this data in cookie 
            // so any requist have the data from cookie 
            ITIContext db = new ITIContext();

            var res = db.Users.Include(a => a.Roles).FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
            if (res == null)
            {
                ModelState.AddModelError("", "Invalid UserName and Password ");
                return View(model);
            }
            Claim c1 = new Claim(ClaimTypes.Name, res.Name);
            // claimtypes.name = key     || res.name = value 
            Claim c2 = new Claim(ClaimTypes.Email, res.Email);
            List<Claim> RoleClaims = new List<Claim>();
            foreach (var item in res.Roles)
            {
                RoleClaims.Add(new Claim(ClaimTypes.Role, item.Name));

            }

            ClaimsIdentity ci = new ClaimsIdentity("Cookies");
            ci.AddClaim(c1);
            ci.AddClaim(c2);
            foreach (var item in RoleClaims)
            {
                ci.AddClaim(item);
            }


            ClaimsPrincipal cp = new ClaimsPrincipal();
            cp.AddIdentity(ci);

            await HttpContext.SignInAsync(cp);

            //SignInAsync : encrypt data and add to cookie

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
