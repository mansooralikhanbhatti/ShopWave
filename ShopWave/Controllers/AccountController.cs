using Microsoft.AspNetCore.Mvc;
using ShopWave.Entities;
using ShopWave.Models;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShopWave
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public IActionResult SubmitLogin(LoginModel loginmodel)
        {
            var dbcontext = new MedicoverDBContext();
            User userObj = dbcontext.Users.FirstOrDefault(p => p.UserName == loginmodel.Username && p.Password == loginmodel.Password);
            if (userObj == null)
            {
                ModelState.AddModelError("", "Entered username or password is incorrect.");
                return View("Login", loginmodel);
            }
            else
            {
                return RedirectToAction("PatientsList", "Patient");
            }
        }

        public IActionResult RegisterForm()
        {
            var model = new RegisterModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveUser(RegisterModel registerModel)
        {
            var dbcontext = new MedicoverDBContext();
            User NewUser = new User();
            NewUser.UserName = registerModel.Username;
            NewUser.Password = registerModel.Password;
            NewUser.Email = registerModel.Email;

            dbcontext.Users.Add(NewUser);
            dbcontext.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
