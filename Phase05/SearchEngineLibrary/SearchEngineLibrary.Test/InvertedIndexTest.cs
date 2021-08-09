using System;
using System.Collections.Generic;
using Xunit;
using Moq;
namespace SearchEngineLibrary.Test
{
    public class InvertedIndexTest
    {
        [Fact]
        public void ShouldTokenizeASample()
        {
            var fileReader= new Mock<IFileReader>();
            var filesContent = new List<Tuple<string, string>>();
            var stopWords = new List<string>()
            {
                "i", 
                "have",
                "a",
                "this",
                "wouldn't",
                "to",
                "be",
                "the",
                "as",
                "is",
                "not",
                "an",
                "if",
                "of"
            };
            
            filesContent.Add(new Tuple<string, string>("57110","I have a 42 yr old male friend"));
            filesContent.Add(new Tuple<string, string>("58043",">This wouldn't happen to be the same thing as chiggers, would it>"));
            filesContent.Add(new Tuple<string, string>("59652","This is not an unusual practice if the doctor is also member of a nudist colony--Sir, I admit your gen'ral rulThat every poet"));
            
            fileReader.Setup(x => x.GetFilesContents()).Returns(filesContent);
            fileReader.Setup(x => x.GetStopWords()).Returns(stopWords);

            IInvertedIndex invertedIndex = new InvertedIndex(fileReader.Object);
            var result = invertedIndex.GetResultListByWord("poet");
            Assert.Contains("59652", result);
        }
        
    }
}