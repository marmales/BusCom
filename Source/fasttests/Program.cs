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

                ChatRoom asd = db.ChatRooms.First();

                asd.Users.Add(db.Users.First(x => x.Nickname == "test1"));
                
                db.SaveChanges();
                foreach (var item in db.Projects)
                {
                    Console.WriteLine(item.ProjectName);
                }

                Console.WriteLine("exit");
                Console.ReadKey();
            }
        }
    }
}
