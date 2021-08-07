using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace SearchEngineLibrary.Test
{
    public class SearchEngineTest
    {
        private HashSet<string> listOfWord_old;
        private HashSet<string> listOfWord_friend;
        private HashSet<string> listOfWord_problem;
        private HashSet<string> listOfWord_doctor;
        private HashSet<string> listOfWord_remember;

        private const string FolderPath = "EnglishDataTest";
        private const string StopWordsPath = "utilities/stopWords.txt";
        
            
        [Fact]
        public void ShouldSearchForProperDocs()
        {
            Mock<IInvertedIndex> invertedIndex = new Mock<IInvertedIndex>();

            listOfWord_old = new HashSet<string>{"57110"};
            listOfWord_friend = new HashSet<string> {"57110"};
            listOfWord_problem = new HashSet<string>{"58045"};
            listOfWord_doctor = new HashSet<string>{"59652"};
            listOfWord_remember = new HashSet<string>{"58045"};

            SetUpMock(invertedIndex);
            
            SearchEngine searchEngine = new SearchEngine(invertedIndex.Object);
            
            string query = "old friend +problem +doctor -remember";
            var results = searchEngine.GetResult(query);
            
            int expectedSize = 2;
            string expectedValue1 = "59652"; 
            string expectedValue2 = "57110"; 
            Assert.Equal(expectedSize, results.Count);
            Assert.Contains(expectedValue1, results);
            Assert.Contains(expectedValue2, results);
        }

        private void SetUpMock(Mock<IInvertedIndex> invertedIndex)
        {
            invertedIndex.Setup(p => p.GetResultListByWord("old")).Returns(listOfWord_old);
            invertedIndex.Setup(p => p.GetResultListByWord("friend")).Returns(listOfWord_friend);
            invertedIndex.Setup(p => p.GetResultListByWord("problem")).Returns(listOfWord_problem);
            invertedIndex.Setup(p => p.GetResultListByWord("doctor")).Returns(listOfWord_doctor);
            invertedIndex.Setup(p => p.GetResultListByWord("remember")).Returns(listOfWord_remember);
        }
    }
}