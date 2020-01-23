﻿using System.IO;
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
          2. extract interface for that new class
          5. bastardize constructor
          6. configure DI
          7. remove bastard constructor
       */

        public string GetGreeting()
        {
            string version = new VersionProvider().GetVersion();
            string parity = int.Parse(version.Split('.').Last()) % 2 == 0 ? "even" : "odd";
            return $"Hello TCDNUG, this is version {version}.  What an {parity} version!";
        }

    }

    public class VersionProvider
    {
        public string GetVersion()
        {
            return File.ReadAllText("version.txt");
        }

    }

}