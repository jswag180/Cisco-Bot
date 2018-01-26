using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CiscoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Reading test reminder file.");
            Console.WriteLine("Starting Cisco Bot");
            discord dis = new discord();
            //TestReminder.getPendingTest();

            while(true)
            {
                switch (Console.ReadLine())
                {
                    case "purge":
                        dis.purge();
                        break;
                    case "stop":
                        TestReminder.saveReminders();
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Command not found!");
                        break;
                }
            }

        }
    }
}
