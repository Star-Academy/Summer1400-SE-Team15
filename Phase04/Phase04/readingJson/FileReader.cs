using System.IO;

namespace readingJson
{
    internal class FileReader : IFileReader
    {
        public string GetFileContent(string path)
        {
            return File.ReadAllText(path);
        }

    }
}
