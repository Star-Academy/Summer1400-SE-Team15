package test.java;

import main.java.IInvertedIndex;
import main.java.ISearchEngine;
import main.java.InvertedIndex;
import main.java.SearchEngine;

import org.junit.jupiter.api.Test;

import java.util.HashSet;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class SearchEngineTest {

    static final IInvertedIndex I_INVERTED_INDEX = mock(InvertedIndex.class);

    @Test
    public void ShouldSearchForProperDocs(){
        HashSet<String> listOfDocsHavingWordOld = new HashSet<>();
        listOfDocsHavingWordOld.add("57110");
        HashSet<String> listOfDocsHavingWordFriend = new HashSet<>();
        listOfDocsHavingWordFriend.add("57110");
        HashSet<String> listOfDocsHavingWordProblem = new HashSet<>();
        listOfDocsHavingWordProblem.add("58045");
        HashSet<String> listOfDocsHavingWordDoctor = new HashSet<>();
        listOfDocsHavingWordDoctor.add("59652");
        HashSet<String> listOfDocsHavingWordRemember = new HashSet<>();
        listOfDocsHavingWordRemember.add("58045");

        when(I_INVERTED_INDEX.getResultListByWord("old")).thenReturn(listOfDocsHavingWordOld);
        when(I_INVERTED_INDEX.getResultListByWord("friend")).thenReturn(listOfDocsHavingWordFriend);
        when(I_INVERTED_INDEX.getResultListByWord("problem")).thenReturn(listOfDocsHavingWordProblem);
        when(I_INVERTED_INDEX.getResultListByWord("doctor")).thenReturn(listOfDocsHavingWordDoctor);
        when(I_INVERTED_INDEX.getResultListByWord("remember")).thenReturn(listOfDocsHavingWordRemember);

        ISearchEngine ISearchEngine = new SearchEngine(I_INVERTED_INDEX);

        Set<String> results = ISearchEngine.getResult("old friend +problem +doctor -remember");
        assertEquals(2, results.size(),"size of result is not equal with actual size");
        assertTrue(results.contains("59652"),"search engine is wrong");
        assertTrue(results.contains("57110"),"search engine is wrong");
    }

}
