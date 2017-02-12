using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCom.Controllers
{
    public class CommitsController : Controller
    {
        // GET: Commits
        public ActionResult Index()
        {
            return View();
        }
    }
}