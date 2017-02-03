using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Core;

namespace fasttests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BuscomContext())
            {

                User u1 = new User()
                {
                    FirstName = "ktos",
                    LastName = "cos",
                    Email = "qwerty",
                    Login = "user2",
                    Nickname = "test2",
                    Password = "pass2"
                };
                User u2 = new User()
                {
                    FirstName = "ktos",
                    LastName = "cos",
                    Email = "qwerty",
                    Login = "user3",
                    Nickname = "test3",
                    Password = "pass2"
                };

                db.Users.Add(u1);
                db.Users.Add(u2);
                db.SaveChanges();
                Console.WriteLine("exit");
                Console.ReadKey();
            }
        }
    }
}
