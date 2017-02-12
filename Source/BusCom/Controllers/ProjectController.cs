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
using BusCom.Models;
using Microsoft.Owin;
namespace BusCom.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private IUsersRepository repository;
        private UserProjects _projects;

        public ProjectController()
        {

        }
        public ProjectController(IUsersRepository usersParam)
        {
            repository = usersParam;
        }

       // public User activeUser { get; set; }
        public UserProjects Projects { get { return _projects; } set { _projects = value; } }

        
        public PartialViewResult ProjectsNavigator()
        {
            if(_projects == null)
            {
                _projects = new UserProjects(repository.EveryUser.Single(x => x.Id == HttpContext.User.Identity.GetUserId()));
            }

            //_projects.ActiveProject = _projects.ActiveUser.Projects.FirstOrDefault() ?? _projects.ActiveUser.AdminProjects.First();
            //if(_projects.ActiveProject == null)
            //    return Redirect("IndexMainWindow")

            return PartialView(_projects);
        }
        public ActionResult MainWindow(int ProjectID = -1)
        {
            if (ProjectID == -1)
            {
                return View();
            }
            else
            {
                _projects = new UserProjects(repository.EveryUser.Single(x => x.Id == HttpContext.User.Identity.GetUserId()));
                _projects.ActiveProject = repository.EveryProject.projects.First(x => x.ProjectId == ProjectID);
            }
        }
        public ActionResult ListUsersInActiveProject()
        {
            //IEnumerable<User> usersInProject = activeProject.Users.Where(x => x.Id != _projects.ActiveUser.Id);
            return View();
        }
        public ActionResult ListChatRooms()
        {
            //IEnumerable<ChatRoom> chatRooms = activeProject.ChatRooms.Intersect(_projects.ActiveUser.ChatRooms);
            return View();
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View(new Project());
        }

        [HttpPost]
        public ActionResult CreateProject(Project newProject)
        {
            if (newProject.ProjectName == null)
                return View("Wrong");

            newProject.Admin = repository.EveryUser.Single(x => x.Id == HttpContext.User.Identity.GetUserId());

            bool result = repository.EveryProject.AddProject(newProject);

            if (result)
                return View("Success");
            else
                return View("Wrong");
        }

        public ActionResult SelectProject(int ProjectID)
        {
            if (_projects == null)
            {
                
            }

            _

            //CommitsController commits = new CommitsController(repository.EveryProject.getCommits(SelectedProject));
            ChatController chatController = new ChatController(repository.EveryProject.getChannels(_projects.ActiveProject));
            return View("MainWindow");
        }
        //private AppUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); } }
        
    }
}