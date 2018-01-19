using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoBot
{
    public static class fanFik
    {
        private static String[] vals = {
                         "n1 talks to n2",
                         "n1 holds hands with n2",
                         "n1 hugs n2",
                         "n1 cuddles with n2",
                         "n1 kisses n2",
                         "n1 and n2 start a relationship",
                         "n1 falls in complete love with n2",
                         "n1 has sex with n2",
                         "n1 has a child with n2",
                         "n1 and n2 grow old together",
                         "n2 is alone after n1 passes away",
                         "n2 gets buried next to n1",
                         "One day, n1 was signing on the sidewalk when n1 flunked into n2. Gosh, how flighty those sepia eyes are. n1 started mugging because that was my crush. That night, n1 dipped about n2. How it would be if n1 and n2 were rhetorical. How it would be if n1 and n2 had sex.. The next day, n1 nuked the guts to explode n2 over to my house. n1 and n2 jogged, and she seemed interested in n1. n1 realized that n1 had been staring at her pretty deltoid the whole time. n1 asked her if she wanted to come to my room. She looked at n1 quizzically, but said she would anyways. When they got in n1's room, she put her gluteus maximus on my triceps and said that she loved n1 since n1 and n2 first met. n1's heart started to do jumping jacks, and told n2 the same. Suddenly, my dandelion went up and n1 asked her if she wanted to see more of n1. She said yes. She slowly unzipped my socks as n1 unbuttoned her t-shirt and undid her underwear. Those tear duct were so perfect. She took off my g-string and n1 and n2 got on the bed when n1 and n2 were naked. n1 and n2 had the best sex ever. It lasted 420 minutes. n1 was so happy. Now n1 and n2 go out every week, and have sex every time they get home.",
                        "Far far away, in a magical far away distant land.. N1 woke up one day and discovered that he was goth. His parents had come to him and told him that he was really adopted and was in fact the decendent of the fallen angel! So while they were picking out black and red clothes and nail polish, n1 tried to fight his tears by listening to Evanessence. Because for the first time in n1's life, he had the feeling someone understood his pain. So n1 listened to the songs in one ear while using his other ear to follow n2's story. But it was so difficult because n1.... really loved n2! N1 knew these were wrong feelings to have because... you know, it's n2 and their love would make life very difficult because n1 also remembered a prophecy that someone had told him in the past (before he was raped) and that said that if n1 would ever fall in love with n2, that then The Evil Joey Clone would find them and kill them! But quickly n1 didn't continue thinking about it. How dare he get this idea in his head? Their love was the greatest (a/n it was, untill The Evil Joey Clone convinced Serenity Darkmoon Raven to switch over to her side! (With sex)) So n1 went in and defeated all the Lackys and the thingy that The Evil Joey Clone had hired until they finally came to the Conservatory The Evil Joey Clone was hiding in. But there the betrayal started. Serenity Darkmoon Raven raised the sword. N1 turned around. \"Prepare to die!\" Serenity Darkmoon Raven shouted. Hahaa! said n1, \"But you can't kill me. Because the only way this sword works, is through the strength of love. \"Indeed, n1 said Serenity Darkmoon Raven. The strength of the love of the other! And with one fierce sweep, Serenity Darkmoon Raven stabbed n1. \"The love of the other!\" Serenity Darkmoon Raven said. Because it was true, n1 still loved Serenity Darkmoon Raven very much. And that love now. That was his undooing. The Evil Joey Clone kicked n1 once more. And then n1 died. The end."
                        };

        public static string GetFic(String n1,String n2)
        {
            Random rng = new Random();
            String fanfc = vals[rng.Next(vals.Length)];
            fanfc = fanfc.Replace("n1",n1);
            return fanfc.Replace("n2", n2);

        }

    }
}
