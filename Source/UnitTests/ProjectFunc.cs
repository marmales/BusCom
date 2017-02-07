using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Core;
using Domain.Entities;
using BusCom.Controllers;
using Moq;
using Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
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
            Mock<IProjectRepository> mock = new Mock<IProjectRepository>();

            assignProjectsToUsers(projects, users);
            mock.Setup(x => x.projects).Returns(projects);

            ProjectController controller = new ProjectController(mock.Object);
            controller.activeUser = users[0];

            IEnumerable<Project> result = (IEnumerable<Project>)controller.ListUserProjects().Model;

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
    }
}