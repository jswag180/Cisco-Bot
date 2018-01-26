using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoBot
{
    static class TestReminder
    {
        //File format jswag180#0270 testName 1/25/2018
        private static List<String> reminders = new List<String> { };
        private static string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static bool addTest(String name,String testName,String date)
        {

            reminders.Add(name + " " + testName + " " + date );
            saveReminders();

            return true;
        }

        public static void removeTest(String entry)
        {

            reminders.Remove(entry);
            saveReminders();

        }

        public static List<String> getPendingTest()
        {
            reminders.Clear();
            var lines = File.ReadAllLines(appPath + @"\reminders.txt");
            foreach (var line in lines)
            {
                reminders.Add(line);
            }

            return reminders;
        }

        public static void saveReminders()
        {

            string remindersPath = appPath + @"\reminders.txt";
            if (File.Exists(remindersPath))
            {
                
                using (StreamWriter sw2 = File.CreateText(remindersPath))
                {
                    foreach(String re in reminders)
                    {
                        sw2.WriteLine(re);
                    }
                    Console.WriteLine("Saving remiders.");
                    sw2.Close();
                }
            }
            else
            {

                using (StreamWriter sr2 = File.CreateText(remindersPath))
                {
                    sr2.Write("");
                    sr2.Close();

                }

            }

        }

    }
}
