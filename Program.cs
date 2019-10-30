using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var configFile = "config";
            var actionsFile = "sequence";

            if (args.Length > 0)
            {
                configFile = args[0];

                if (args.Length > 1)
                {
                    actionsFile = args[1];
                }
            }
            MinefieldGame game = new MinefieldGame();
            game.getSequence(configFile,
                                  actionsFile);
        }
    }
}
