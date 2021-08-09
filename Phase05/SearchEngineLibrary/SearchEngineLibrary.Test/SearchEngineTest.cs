using System.Collections.Generic;
using Xunit;
using Moq;

namespace SearchEngineLibrary.Test
{
    public class SearchEngineTest
    {
        private HashSet<string> _listOfWordForOld;
        private HashSet<string> _listOfWordForFriend;
        private HashSet<string> _listOfWordForProblem;
        private HashSet<string> _listOfWordForDoctor;
        private HashSet<string> _listOfWordForRemember;
        
        [Fact]
        public void ShouldSearchForProperDocs()
        {
            var invertedIndex = new Mock<IInvertedIndex>();

            _listOfWordForOld = new HashSet<string>{"57110"};
            _listOfWordForFriend = new HashSet<string> {"57110"};
            _listOfWordForProblem = new HashSet<string>{"58045"};
            _listOfWordForDoctor = new HashSet<string>{"59652"};
            _listOfWordForRemember = new HashSet<string>{"58045"};

            SetUpMock(invertedIndex);
            
            ISearchEngine searchEngine = new SearchEngine(invertedIndex.Object);
            
            var query = "old friend +problem +doctor -remember";
            var results = searchEngine.GetResult(query);
            
            var expectedSize = 2;
            var expectedValue1 = "59652"; 
            var expectedValue2 = "57110"; 
            Assert.Equal(expectedSize, results.Count);
            Assert.Contains(expectedValue1, results);
            Assert.Contains(expectedValue2, results);
        }

        private void SetUpMock(Mock<IInvertedIndex> invertedIndex)
        {
            invertedIndex.Setup(p => p.GetResultListByWord("old")).Returns(_listOfWordForOld);
            invertedIndex.Setup(p => p.GetResultListByWord("friend")).Returns(_listOfWordForFriend);
            invertedIndex.Setup(p => p.GetResultListByWord("problem")).Returns(_listOfWordForProblem);
            invertedIndex.Setup(p => p.GetResultListByWord("doctor")).Returns(_listOfWordForDoctor);
            invertedIndex.Setup(p => p.GetResultListByWord("remember")).Returns(_listOfWordForRemember);
        }
    }
}