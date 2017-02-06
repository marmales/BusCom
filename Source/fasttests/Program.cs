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
            BuscomContext db = new BuscomContext();
            Console.WriteLine("exit");
            Console.ReadKey();
        }
    }
}

