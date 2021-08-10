using System.Linq;
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
            var filesContent = fileReader.GetFilesContents();
            var temp = filesContent
                                        .FirstOrDefault(file => file.Item1.Equals("57110"));
            Assert.NotNull(temp);
            Assert.Equal("i have a 42 yr old male friend",temp.Item2);
        }

        [Fact]
        public void ShouldCreateStopWordsList()
        {
            IFileReader fileReader = new FileReader(_folderPath, _stopWordsPath);
            var stopWords = fileReader.GetStopWords();
            Assert.Equal("a",stopWords[0]);
        }
        
        
    }
}
