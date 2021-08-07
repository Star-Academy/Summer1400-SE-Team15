using System;
using System.Collections.Generic;
using Xunit;

namespace SearchEngineLibrary.Test
{
    public class FileReaderTest
    {
        private readonly string _folderPath = "../../../EnglishDataTest";
        private readonly string _stopWordsPath = "../../../utilities/stopWords.txt";
        [Fact]
        public void ShouldCreateData()
        {
            IFileReader fileReader = new FileReader(_folderPath,_stopWordsPath);
            List<Tuple<string, string>> filesContent = fileReader.GetFilesContents();
            Tuple<string, string> temp = null;
            foreach (var file in filesContent)
            {
                if (file.Item1.Equals("57110"))
                {
                    temp = file;
                    break;
                }
            }
            Assert.NotNull(temp);
            Assert.Equal("i have a 42 yr old male friend",temp.Item2);
        }

        [Fact]
        public void ShouldCreateStopWordsList()
        {
            IFileReader fileReader = new FileReader(_folderPath, _stopWordsPath);
            List<string> stopWords = fileReader.GetStopWords();
            Assert.Equal("a",stopWords[0]);
        }
        
        
    }
}
