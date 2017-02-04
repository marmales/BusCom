
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Domain.Core;

namespace BusCom.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
        private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } }
    }
}