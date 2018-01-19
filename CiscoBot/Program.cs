using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Cisco Bot");
            discord dis = new discord();
            while(true)
            {
                switch (Console.ReadLine())
                {
                    case "purge":
                        dis.purge();
                        break;

                    default:
                        Console.WriteLine("Command not found!");
                        break;
                }
            }

        }
    }
}
