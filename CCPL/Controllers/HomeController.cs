using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CCPL.Models;

namespace CCPL.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Validate(FormCollection form)
        {
            string user = form["userID"].Trim();
            string password = form["password"].Trim();
            if (user == "USERNAME" || password == "Password")
            {
                return View("Error");
            }
            int result = new CCPL.Models.User().ValidateUser(user, password);
            return View();
        }
        public ActionResult Logout()
        {
            return View("Login");
        }
        
        public ActionResult StockEntry()
        {
            return View(new Masters().StockDropDowns());
        }
        [HttpPost]
        public ActionResult StockEntrySubmit(Stock stock)
        {
            ViewBag.Message = "Success Stock Entry";
            if (ModelState.IsValid)
                return View("Error");
            else
                return View("StockEntry", new Masters().StockDropDowns());
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        

    }
    
}