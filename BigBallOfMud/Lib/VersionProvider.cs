using System.IO;

namespace BigBallOfMud.Lib
{
    public class VersionProvider : IVersionProvider
    {
        public string GetVersion() => File.ReadAllText("version.txt");

    }

}