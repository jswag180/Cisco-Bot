using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace CiscoBot
{
    public class discord
    {      
        public static String[] Admins;
        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private string Token = "";//MzcyNTA5NTgyNDAyMjU2ODk2.DPJ3Bg.SVTrHSUzEQIBgCPS2wB-kXha61I
        public DiscordSocketClient Client;
        public DiscordSocketConfig conf;

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
            if (arg.Content.StartsWith("!") && !arg.Author.IsBot)
            {                
                string message = arg.Content.Substring(1);
                Console.WriteLine("Command receved: " + message);
                if (arg.Channel.Id.ToString() == "382025759553880064")
                {
                    string response = cmd.compute(message);
                    if (response == "tests")
                    {
                        new Message(arg.Author as SocketUser, arg.Content, new Uri("https://www.google.com/"), new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
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
                    if (response == "tests")
                    {
                        new Message(arg.Author as SocketUser, arg.Content, new Uri("https://www.google.com/"), new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                    }
                    else {
                        new Message(arg.Author as SocketUser, arg.Content, response, new Color(0x193272), DateTimeOffset.Now.ToUnixTimeMilliseconds()).Send(arg.Channel);
                    }
                    Console.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "> ");
                    Console.WriteLine(response + " Was said Requested by: " + arg.Author.Username);
                }
                return Task.Run(() => { Console.WriteLine("Ended Task (Method)"); });
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
