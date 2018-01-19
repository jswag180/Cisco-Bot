using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoBot
{
    public static class starFox
    {
       private static string[] Foxy = {
            "Never give up. Trust your instincts.",
            "Hey, Einstein! I'm on your side!",
            "Now you will feel TRUE PAIN!",
            "We're Star Fox!",
            "Enemy shield analyzed",
            "You worry about your own hide.",
            "You know that I control the galaxy.",
            "Andross' enemy is my enemy!",
            "We're heading out. All aircraft report.",
            "You’re becoming more like your Father!",
            "Something’s wrong with the G-diffuser!",
            "So you’re going to attack the enemy base? Great idea Starfox!",
            "Location confirmed. Sending supplies.",
            "Can't let you do that, Star Fox!",
            "I’m monkey food if I don’t leave!",
            "I ain’t your buddy, go away!",
            "Bulldog unit, don’t let anything through!",
            "Knock it off, Fox!",
            "Bow before the great Andross!",
            "You’re pretty good, Tiger. See you again!",
            "Venom, here we come!",
            "Hey! What’s the big idea?",
            "This way, Fox",
            "You're good, but I'm better!",
            "I’ll take this one. Get the one behind me!",
            "I guess I should be thankful.",
            "I'll do you fast, Peppy ol' pal!",
            "Recover our base from the enemy army!",
            "Yippee!! You did it!",
            "The hatches are open!",
            "Sorry to jet, but I'm in a hurry!",
            "You did it! I was worried for a moment." };

        public static string GetFox()
        {
            Random rng = new Random();
            return Foxy[rng.Next(Foxy.Length)];
        }
    }
}
