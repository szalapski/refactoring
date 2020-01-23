using System.IO;
using System.Linq;

namespace BigBallOfMud.Lib
{
    public class GreetingProvider : IGreetingProvider
    {
        /* Refactor static or tightly-coupled instance ("new") dependency into proper DI in 7 steps:
          
          1. (static only) Sequester the untestable/uninjectable code into a tightly-coupled implementation
            a. extract instance method
            b. extract instance class from that method
            c. use the new class and method with "new"
          2. make local for the "new" object only
          3. move local to instance
          4. bastardize constructor
          6. configure DI
          7. remove bastard constructor
          N. clean up code (always)
       */
        private VersionProvider _versionProvider;
        public GreetingProvider(VersionProvider versionProvider)
        {
            _versionProvider = versionProvider ?? throw new System.ArgumentNullException(nameof(versionProvider));
        }
        public GreetingProvider()
        {
            _versionProvider = new VersionProvider();
        }

        public string GetGreeting()
        {
            string version = _versionProvider.GetVersion();
            string parity = int.Parse(version.Split('.').Last()) % 2 == 0 ? "even" : "odd";
            return $"Hello TCDNUG, this is version {version}.  What an {parity} version!";
        }

    }

    public class VersionProvider : IVersionProvider
    {
        public string GetVersion()
        {
            return File.ReadAllText("version.txt");
        }

    }

}