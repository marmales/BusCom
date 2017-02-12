using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCom.Models
{
    public class UserProjects
    {
        private User _user;

        public User ActiveUser { get { return _user; } }
        public Project ActiveProject { get; set; }
        public IEnumerable<Project> Projects
        {
            get { return _user.Projects.Union(_user.AdminProjects); }
        }
        public IEnumerable<User> ListUsers
        {
            get
            {
                return ActiveProject == null ? 
                    new List<User>() : 
                    (ActiveProject.Users.Union(new List<User> { ActiveProject.Admin })).Where(x => x.Id != _user.Id);
            }
        }
        public UserProjects(User activeUser)
        {
            _user = activeUser;
        }
        public Project CreateProject(string ProjectName)
        {
            Project newProject = new Project()
            {
                ProjectName = ProjectName,
                Admin = _user,
                AdminId = _user.Id
            };
            return newProject;
        }
    }
}