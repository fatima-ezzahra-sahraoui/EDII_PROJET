using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDI_prjct.Models;

namespace EDI_Project.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            using (RDbContext db = new RDbContext())
            {
                return View(db.Utilisateurs.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Utilisateur account)
        {
            if (ModelState.IsValid)
            {
                using (RDbContext db = new RDbContext())
                {
                    db.Utilisateurs.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registred. ";
            }
            return View();
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Utilisateur user)
        {
            using (RDbContext db = new RDbContext())
            {
                var usr = db.Utilisateurs.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("create","Fichier_EDI");
                }
                else
                {
                    ModelState.AddModelError(" ", "UserName or Password is Wrong .");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}