using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;
namespace BusCom.Controllers
{
    [Authorize]

    public class ProjectController : Controller
    {
        IProjectRepository repository;
        public ProjectController(IProjectRepository projectsParam)
        {
            repository = projectsParam;
        }
        public ActionResult List()
        {
            ViewBag.Type = User.Identity.GetUserId<int>().GetType();

            ViewBag.Wartosc = System.Web.HttpContext.Current.User.Identity.GetUserId<int>();
            return View(repository.projects);
        }
    }
}