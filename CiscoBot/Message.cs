using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CiscoBot
{
    public class Message
    {
        public Embed embeded;
        public Message(SocketUser User, String Body, String title, Discord.Color clr, long Epoch)
        {
                var builder = new EmbedBuilder()
            .WithTitle(title)
            .WithDescription(Body)
            .WithColor(clr)
            .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(Epoch))
            .WithAuthor(author => { author
            .WithName(User.Username)
            .WithIconUrl(User.GetAvatarUrl());});
            embeded = builder.Build();
            Console.WriteLine(User.GetAvatarUrl());
        }
        public Message(SocketUser User,String urlText,Uri uri,Discord.Color clr, long Epoch)
        {

            var builder = new EmbedBuilder()
            .WithTitle("Cisco Bot source code.")
            .WithUrl(uri.ToString())
            .WithDescription(urlText)
            .WithColor(clr)
            .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(Epoch))
            .WithAuthor(author => { author
            .WithName(User.Username)
            .WithIconUrl(User.GetAvatarUrl());
            });
            embeded = builder.Build();
            Console.WriteLine(User.GetAvatarUrl());

        }

        public async Task Send(IMessageChannel chn)
        {
            await chn.SendMessageAsync("", embed: embeded);
        }

        public async Task Send(IUser user)
        {
            await user.SendMessageAsync("", embed: embeded);
        } 
    }
}
