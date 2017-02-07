using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Domain.Entities;
using Domain.Core;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace BusCom.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        IProjectRepository repository;
        Project activeProject;
        public User activeUser { get; set; }
        private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } }

        public ProjectController(IProjectRepository projectsParam)
        {
            repository = projectsParam;
            if(HttpContext != null)
            activeUser = UserManager.FindById(HttpContext.User.Identity.GetUserId());

        }
        public ViewResult ListUserProjects()
        {
            return View(activeUser.Projects.Union(activeUser.AdminProjects));
        }

        public ActionResult ListUsersInActiveProject()
        {
            IEnumerable<User> usersInProject = activeProject.Users.Where(x => x.Id != activeUser.Id);
            return View(usersInProject);
        }
        public ActionResult ListChatRooms()
        {
            IEnumerable<ChatRoom> chatRooms = activeProject.ChatRooms.Intersect(activeUser.ChatRooms);
            return View(chatRooms);
        }
    }
}