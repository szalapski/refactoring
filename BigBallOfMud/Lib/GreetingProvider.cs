using System.IO;

namespace BigBallOfMud.Lib
{
    public class GreetingProvider : IGreetingProvider
    {
        public string GetGreeting() => $"Hello TCDNUG, this is version {File.ReadAllText("version.txt")}";
    }
}
