using System.IO;

namespace BigBallOfMud.Lib
{
    public class VersionProvider : IVersionProvider
    {
        public string GetVersion()
        {
            return File.ReadAllText("version.txt");
        }
    }
}