using System.IO;

namespace readingJson
{
    class FileReader
    {
        private string _path ;

        public FileReader(string path)
        {
            this._path = path;
        }

        public string GetFileContent()
        {
            return File.ReadAllText(_path);
        }

    }
}
