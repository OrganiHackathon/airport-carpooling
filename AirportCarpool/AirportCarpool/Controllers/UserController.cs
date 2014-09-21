using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportCarpool.Models;
using WebMatrix.WebData;

using System.Web.Security;
using System.Data.Entity;

namespace AirportCarpool.Controllers
{
    public class UserController : Controller
    {
        AirportCarpoolDbContext _db = new AirportCarpoolDbContext();

        [Authorize]
        [HttpGet]
        public ActionResult Index([Bind(Prefix = "id")] string userName)
        {
            User user = GetUserByUserName(userName);
            return View(user.ViewModel());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegister model)
        {
            User user;
            if (ModelState.IsValid)
            {
                //controle of user bestaat
                if (!WebSecurity.UserExists(model.UserName))
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    Roles.AddUserToRole(model.UserName, "user"); //todo: roles niet hardcoden

                    //initialize al de rest van het userobject 

                    user = GetUserByUserName(model.UserName);

                    user.Email = model.Email;
                    user.GSM = string.Empty;
                    user.Name = string.Empty;
                    user.SurName = string.Empty;
                    _db.Entry(user).State = EntityState.Modified;
                    _db.SaveChanges();

                    WebSecurity.Login(model.UserName, model.Password);

                }
            }

            return RedirectToAction("index", "home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditUserProfile(UserViewModel userVM)
        {
            //todo: locationid gaat hier verloren
            //if (user.Location == null && loc != null) {
            //    user.Location = loc;
            //}
            return View(userVM);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateUserProfile(UserViewModel userVM)
        {
            User user = GetUserByUserName(userVM.UserName);

            user.FillFromViewModel(userVM);

            _db.Entry(user).State = EntityState.Modified;
           
            _db.SaveChanges();

            return RedirectToAction("Index", "User", new { id = user.UserName });
        }


        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult UserLocation(User user)
        {
            return View(user);
        }

        private User GetUserByUserName(string userName)
        {
            
            User user = _db.Users.Include(u => u.Location).Where(u => u.UserName == userName).Single<User>();
            if (user.Location == null)
            {
                user.Location = new Location();
                _db.SaveChanges();
            }

            //return (from u in _db.Users
            //               where u.UserName == userName
            //               select u).SingleOrDefault<User>();


            return user;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
