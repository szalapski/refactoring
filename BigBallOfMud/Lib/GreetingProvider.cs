using System.IO;
using System.Linq;

namespace BigBallOfMud.Lib
{
    public class GreetingProvider : IGreetingProvider
    {
        /* Refactor static/ dependency into proper DI in 7 steps:
          
          1. Sequester the untestable/uninjectable code into a tightly-coupled implementation
            a. extract method
            b. extract class from that method
          2. extract interface for that new class
          5. bastardize constructor
          6. configure DI
          7. remove bastard constructor
       */

        public string GetGreeting()
        {
            string version = File.ReadAllText("version.txt");
            string parity = int.Parse(version.Split('.').Last()) % 2 == 0 ? "even" : "odd";
            return $"Hello TCDNUG, this is version {version}.  What an {parity} version!";
        }
    }
}