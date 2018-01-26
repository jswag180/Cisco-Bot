using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace CiscoBot
{
    public class discord
    {      
        public static String[] Admins;
        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private string Token = "";
        public DiscordSocketClient Client;
        public DiscordSocketConfig conf;
        public bool isCharRe = false;
        public List<String> op = new List<string> {"jswag180#0270"};
        public List<String> fastTrack = new List<string> { "jswag180#0270", "eugenedtyp#9173" , "camzilla727#3616", "CarefulCracker5#4840", "kingjk#6229", "RAGE COUNSELING#2838", "s0mething#8988", "Scrogginaut#8010"};

        public discord()
        {
            Console.WriteLine("init");
            init();
        }

        private async Task init()
        {
            conf = new DiscordSocketConfig();
            conf.MessageCacheSize = 1000;            
            Client = new DiscordSocketClient(conf);
            await getToken();
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
            Console.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "> Ready!");
            Client.MessageReceived += Client_MessageReceived;
            Client.MessageDeleted += Client_MessageDeleted;

            Thread t = new Thread(delegate ()
            {

                while (true)
                {
                    Thread.Sleep(1000);
                    List<String> pendingTestRemiders = TestReminder.getPendingTest();

                    if (pendingTestRemiders.Count() > 0)
                    {

                        Console.WriteLine("Cheking reminders");
                        foreach (String reminder in pendingTestRemiders)
                        {
                            List<string> Args = new List<string>();
                            Args = reminder.Split(' ').ToList();// 0 = name, 1 = test name, 2 = date
                            if (DateTimeOffset.FromUnixTimeMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds()).ToString().Contains(Args[2]))
                            {
                                //send reminder to name
                                Console.WriteLine("Reminder for " + Args[0]);
                                List<string> nameSplit = new List<string>();
                                nameSplit = Args[0].Split('#').ToList();
                                //Discord.UserExtensions.SendMessageAsync(Client.GetUser(nameSplit[0], nameSplit[1]), "Reminder");
                                new Message(Client.GetUser(nameSplit[0], nameSplit[1]) as SocketUser, "Remember your test : " + Args[1] + " for : " + Args[2] , "Test reminder", new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(Client.GetUser(nameSplit[0], nameSplit[1]));
                                TestReminder.removeTest(reminder);
                                break;
                            }

                        }
                    }
                }

            });
            t.Start();

        }

        private Task Client_MessageDeleted(Cacheable<IMessage, ulong> arg1, ISocketMessageChannel arg2)
        {
            if (arg1.HasValue)
            {
                if (!arg1.Value.Author.IsBot && arg1.Value.Content.StartsWith("!"))
                {
                    if (arg2.Id.ToString() == "382025759553880064")
                    {
                        if (cmd.compute(arg1.Value.Content.Substring(1)) != "Command not found " + cmd.Faces.sad)
                        {
                            new Message(arg1.Value.Author as SocketUser, arg1.Value.Content, arg1.Value.Author.Username + " Tried to Hide their message " + cmd.Faces.hacked, new Color(0xC00003), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg1.Value.Channel);
                        }
                    }
                    else
                    {
                        if (cmd.compute(arg1.Value.Content.Substring(1)) != cmd.Faces.pissed + " Put it in the right channel. " + cmd.Faces.angry)
                        {
                            new Message(arg1.Value.Author as SocketUser, arg1.Value.Content, arg1.Value.Author.Username + " Tried to Hide their message " + cmd.Faces.hacked, new Color(0xC00003), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg1.Value.Channel);
                        }
                    }
                }
            }
            return Task.Run(() => { });
        }

        private Task Client_MessageReceived(SocketMessage arg)
        {
            //382025759553880064
            //Console.WriteLine(arg.Channel.Name);//dms are @name#num
            if (!arg.Channel.Name.ToString().Equals(arg.Author.ToString().Insert(0, "@"))) {
                if (isCharRe)
                {
                    if (arg.Author.ToString() == "McLovin McBoys#7682")
                    {
                        new Message(arg.Author as SocketUser, "Charles you're retarded", "Reminder", new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                    }
                }
                if (arg.Content.StartsWith("!") && !arg.Author.IsBot)
                {
                    string message = arg.Content.Substring(1);
                    Console.WriteLine("Command receved: " + message);
                    if (arg.Channel.Id.ToString() == "382025759553880064")
                    {
                        string response = cmd.compute(message);
                        if (response == "git")
                        {
                            new Message(arg.Author as SocketUser, arg.Content, new Uri("https://github.com/jswag180/Cisco-Bot"), new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                        }
                        else
                        {
                            new Message(arg.Author as SocketUser, arg.Content, response, new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                        }
                        Console.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "> ");
                        Console.WriteLine(response + " Was said Requested by: " + arg.Author.Username);
                    }
                    else
                    {
                        string response = cmd.SepCompute(message);
                        if (response == "git")
                        {
                            new Message(arg.Author as SocketUser, arg.Content, new Uri("https://github.com/jswag180/Cisco-Bot"), new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                        }
                        else {
                            new Message(arg.Author as SocketUser, arg.Content, response, new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                        }
                        Console.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "> ");
                        Console.WriteLine(response + " Was said Requested by: " + arg.Author.Username);
                    }
                    return Task.Run(() => { Console.WriteLine("Ended Task (Method)"); });
                }
            } else if (op.Contains(arg.Author.ToString()))
            {
                Console.WriteLine("Recived cmd from pm: " + arg.Author.ToString());
                String msg = arg.Content.ToLower();
                List<string> Args = new List<string>();
                Args = msg.Split(' ').ToList();
                String command = Args[0];
                Args.RemoveAt(0);
                
                switch (command)
                {
                    case "ischarre":
                        if (isCharRe)
                        {
                            isCharRe = false;
                        }
                        else
                        {
                            isCharRe = true;
                        }
                        new Message(arg.Author as SocketUser, "Toggling isCharRe: " + isCharRe, "Toggle", new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                        break;
                    case "listft":

                        String fastTrackList = "";
                            
                            for(int i = 0;i < fastTrack.Count; i++)
                            {

                            fastTrackList = fastTrackList + i + ":" +fastTrack[i] + "\n";

                            }
                            new Message(arg.Author as SocketUser, fastTrackList, "Fast track List", new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);

                        
                        break;
                    case "addtestre":

                        int studentNum = int.Parse(Args[0]);
                        String testDate = Args[2];
                        String testName = Args[1];

                        TestReminder.addTest(fastTrack[studentNum],testName,testDate);

                        
                        new Message(arg.Author as SocketUser, "for " + fastTrack[studentNum] + " on " + testDate + " for test " + testName, "Test reminder set!", new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                        break;
                }
            }
            return Task.Run(() => { });
        }

        public void purge()
        {
           
        }

        public Task getToken()
        {

            string tokenPath = appPath + @"\token.txt";
            if (!File.Exists(tokenPath))
            {
                // Create a file to write to.
                using (StreamWriter sw2 = File.CreateText(tokenPath))
                {
                    sw2.WriteLine("");
                    Console.WriteLine("token.txt not found making one.Plase put token inside this : " + tokenPath);
                }
            }
            else
            {

                using (StreamReader sr2 = File.OpenText(tokenPath))
                {
                    Token = sr2.ReadLine();
                }

            }

            return Task.Run(() => { });

        }

    }
}
