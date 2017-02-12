using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Core;
using Domain.Entities;
using BusCom.Controllers;
using Moq;
using Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using BusCom.Models;

namespace UnitTests
{
    [TestClass]
    public class ProjectFunc
    {
        [TestMethod]
        public void ListProjectForActiveUser()
        {
            List<User> users = new List<User> { new User(), new User() };
            List<Project> projects = CreateProjects(users[0], users[1]);
            Mock<IUsersRepository> mock = new Mock<IUsersRepository>();

            assignProjectsToUsers(projects, users);
            mock.Setup(x => x.EveryUser).Returns(users);

            ProjectController controller = new ProjectController(mock.Object);
            controller.Projects = new UserProjects(users[0]);
            controller.activeUser = users[0];

            IEnumerable<Project> result = ((UserProjects)controller.ProjectsNavigator().Model).Projects;

            Project[] projArray = result.ToArray();
            Assert.IsTrue(projArray.Count() == 4);
            Assert.AreEqual(projArray[0].ProjectId, 1);
            Assert.AreEqual(projArray[1].ProjectId, 2);
            Assert.AreEqual(projArray[2].ProjectId, 3);
            Assert.AreEqual(projArray[3].ProjectId, 5);

        }     
        private List<Project> CreateProjects(User user1, User user2)
        {
            return new List<Project>
            {
                new Project {ProjectId = 1, ProjectName = "Project1", Users = new List<User>{user1, user2 } },
                new Project {ProjectId = 2, ProjectName = "Project2", Users = new List<User>{user1, user2 } },
                new Project {ProjectId = 3, ProjectName = "Project3", Users = new List<User>{user1 } },
                new Project {ProjectId = 4, ProjectName = "Project4", Users = new List<User>{user2 } },
                new Project {ProjectId = 5, ProjectName = "Project5", Users = new List<User>{}, Admin = user1 }
            };
        }
        private void assignProjectsToUsers(List<Project> projects, List<User> users)
        {
            for (int i = 0; i < 2; i++)
            {
                users[0].Projects.Add(projects[i]);
                users[1].Projects.Add(projects[i]);
            }
            users[0].Projects.Add(projects[2]);
            users[1].Projects.Add(projects[3]);
            users[0].AdminProjects.Add(projects[4]);
        }
        [TestMethod]
        public void ListUsersForProject()
        {
            List<User> users = new List<User> { new User(), new User() };
            List<Project> projects = new List<Project> { new Project() { ProjectId = 1, ProjectName = "Asd", Admin = users[0] } };
            projects[0].Users.Add(users[1]);
            users[0].AdminProjects.Add(projects[0]);
            users[1].Projects.Add(projects[0]);

            Mock<IUsersRepository> mock = new Mock<IUsersRepository>();
            mock.Setup(x => x.EveryUser).Returns(users);

            ProjectController controller = new ProjectController(mock.Object);
            controller.Projects = new UserProjects(users[0]);
            controller.activeUser = users[0];
            controller.Projects.ActiveProject = projects[0];

            IEnumerable<User> result = ((UserProjects)controller.ProjectsNavigator().Model).ListUsers;

            int UsersCount = result.Count();
            Assert.AreEqual(1, UsersCount);
        }
    }
}