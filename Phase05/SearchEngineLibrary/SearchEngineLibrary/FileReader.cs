using System;
using System.Collections.Generic;
using System.IO;

namespace SearchEngineLibrary
{
    public class FileReader : IFileReader
    {
        private const string NonCharRegex = "[^a-zA-Z0-9 -]";
        private readonly string _folderPath;
        private readonly string _stopWordsPath;

        public FileReader(string folderPath, string stopWordPath)
        {
            _folderPath = folderPath;
            _stopWordsPath = stopWordPath;
        }

        public List<Tuple<string, string>> GetFilesContents()
        {
            List<Tuple<string, string>> filesContent = new List<Tuple<string, string>>();
            foreach (string file in Directory.GetFiles(_folderPath))
            {
                filesContent.Add(new Tuple<string, string>(Path.GetFileName(file),GetContentFromFile(file)));
            }

            return filesContent;
        }

        public List<string> GetStopWords()
        {
            return new List<string>(File.ReadAllLines(_stopWordsPath));
        }

        private string GetContentFromFile(string path)
        {
            return GetNormalizedString(File.ReadAllText(path));
        }

        private string GetNormalizedString(string content)
        {
            content = NonCharRegex.Replace(content, " ");
            return content.ToLower();
        }
    }
}
