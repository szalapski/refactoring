﻿using System.Linq;

namespace BigBallOfMud.Lib
{
    public class GreetingProvider : IGreetingProvider
    {
        /* Refactor static/ dependency into proper DI in 7 steps:
          1. (static only) Sequester the untestable/uninjectable code into a class containing
            only the tightly-coupled code
	        a. extract instance method
	        b. extract instance class from that method
	        c. use the new class and method with "new"
          2. make local reference for the "new" object only
          3. move local to instance 
          4. modify the instance fields to an abstract type (i.e. interface)
          5. introduce proper constructor and bastardize old constructor
          6. configure DI at composition root
          7. remove bastard constructor
          N. clean up code (always)        
        */
        private IVersionProvider versionProvider = new VersionProvider();

        public GreetingProvider(IVersionProvider versionProvider) => 
            this.versionProvider = versionProvider ?? throw new System.ArgumentNullException(nameof(versionProvider));

        public string GetGreeting()
        {
            string version = versionProvider.GetVersion();
            string parity = int.Parse(version.Split('.').Last()) % 2 == 0 ? "even" : "odd";
            return $"Hello TCDNUG, this is version {version}.  What an {parity} version!";
        }

      
    }
}