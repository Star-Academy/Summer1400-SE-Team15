using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchEngineEfCore
{
    public class FileReader : IFileReader
    {
        private static readonly Regex NonCharRegex = new Regex("[^a-zA-Z0-9 -]");
        private readonly string _folderPath;
        private readonly string _stopWordsPath;

        public FileReader(string folderPath, string stopWordPath)
        {
            _folderPath = folderPath;
            _stopWordsPath = stopWordPath;
        }

        public List<FileTuple> GetFilesContents()
        {
            return Directory.GetFiles(_folderPath)
                .Select(file => new FileTuple(Path.GetFileName(file), GetContentFromFile(file)))
                .ToList();
        }

        public HashSet<string> GetStopWords()
        {
            return new HashSet<string>(File.ReadAllLines(_stopWordsPath));
        }

        private string GetContentFromFile(string path)
        {
            return GetNormalizedString(File.ReadAllText(path));
        }

        private string GetNormalizedString(string content)
        {
            var replace = NonCharRegex.Replace(content, " ");
            return replace.ToLower();
        }
    }
}
