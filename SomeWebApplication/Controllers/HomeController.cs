using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessModels;
using DataAccessLayer.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SomeWebApplication.Utilities;

namespace SomeWebApplication.Controllers
{
    public class HomeController : BaseController
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
            ViewBag.Message = "Your Login page.";

            return View();
        }
        [HttpPost]
        [ActionNameAttribute("Login")]
        public ActionResult LoginPost(UserModel model)
        {
            TryUpdateModel(model);
            if (ModelState.IsValid)
            {
                var loginProcessor = DependencyResolver.Current.GetService<IAuthorise>();
                if (loginProcessor.IsAuthorisedUser(model))
                {
                    Session["User"] = model;
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    return RedirectToAction("DashBoard", "Some");
                }
            }
            Logging.LogInfo("Login Faliure", true);
            ModelState.AddModelError("LoginError","Login Failed, Please try again");
            return View("Login",model);
        }
        
        [ActionNameAttribute("LoginOff")]
        public ActionResult LoginOff(UserModel model)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Manage()
        {
            ViewBag.Message = "Your Login page.";

            return View("Login");
        }
    }
}