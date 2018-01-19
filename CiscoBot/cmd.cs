using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoBot
{
    public static class cmd
    {
        public struct Faces
        {
            public static string happy = "(✿◠‿◠)";
            public static string angry = "(◣_◢)";
            public static string sad = "(o(╥﹏╥)o";
            public static string upset = "(〴⋋_⋌〵)";
            public static string pissed = "╚(•⌂•)╝";
            public static string horny = "(✿ ♥‿♥)";
            public static string kawii = "(人◕ω◕)";
            public static string casual = "(●´ω｀●)";
            public static string scared = "（／_＼）";
            public static string hacked = "(⌐▨_▨)";
            public static string bored = "(ᴗ˳ᴗ)";
            public static string suprised = "(⊙︿⊙✿";
        }

        public static string compute(String cmd)
        {
            String Command = "";
            List<string> Args = new List<string>();
            Args = cmd.Split(' ').ToList();
            Command = Args[0];
            Args.RemoveAt(0);

            switch (Command.ToLower())
            {
                case "ff":
                    return fanFik.GetFic(Args[0], Args[1]) + " " + Faces.horny;

                case "starfox":
                    
                    return starFox.GetFox() + " " + Faces.happy;

                case "about":
                    return "Brought to you by the memers!" + " " + Faces.horny;

                case "tests":
                    return "tests";

                default:

                    return "Command not found. You do not know de way. " + Faces.sad;
            }

        }

        public static string SepCompute(String cmd)
        {
            String Command = "";
            List<string> Args = new List<string>();
            Args = cmd.Split(' ').ToList();
            Command = Args[0];
            Args.RemoveAt(0);

            switch (Command.ToLower())
            {
                case "starfox":
                    return starFox.GetFox() + " " + Faces.happy;


                case "about":
                    return "Brought to you by the memers!" + " " + Faces.horny;

                case "ff":

                    return Faces.pissed + " Put it in the right channel. " + Faces.angry;
                case "tests":
                    return "tests";

                default:

                    return "Command not found. You do not know de way. " + Faces.sad;
            }
        }

    }
}
