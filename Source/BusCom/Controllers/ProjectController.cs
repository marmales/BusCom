using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BusCom.Controllers
{
    public class ProjectController : Controller
    {
        IProjectRepository repository;
        public ProjectController(IProjectRepository projectsParam)
        {
            repository = projectsParam;
        }
        public ActionResult List()
        {
            return View(repository.projects);
        }
    }
}