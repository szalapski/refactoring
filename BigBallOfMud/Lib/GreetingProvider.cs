using System.IO;
using System.Linq;

namespace BigBallOfMud.Lib
{
    public class GreetingProvider : IGreetingProvider
    {
        /* Refactor static/ dependency into proper DI in 6 steps:
          1. make instance from local
          2. extract interface
          3. make tightly-coupled implementation
          4. bastardize constructor
          5. configure DI
          6. remove bastard constructor
       */

        public string GetGreeting()
        {
            string version = File.ReadAllText("version.txt");
            string parity = int.Parse(version.Split('.').Last()) % 2 == 0 ? "even" : "odd";
            return $"Hello TCDNUG, this is version {version}.  What an {parity} version!";
        }
    }
}