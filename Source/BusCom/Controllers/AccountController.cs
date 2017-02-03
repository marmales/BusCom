using BusCom.Infrastructure.Abstract;
using BusCom.Models;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BusCom.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository _users;
        private IAuthProvider _authProvider;
        public AccountController(IAuthProvider providerParam)
        {
            _authProvider = providerParam;
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.Username, model.Password))
                    return Redirect(returnUrl ?? Url.Action("List", "Project"));
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View();
                }
            }
            else
                return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("List", "Project");
        }
    }
}