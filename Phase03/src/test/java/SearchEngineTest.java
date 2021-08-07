package test.java;

import main.java.InvertedIndex;
import main.java.SearchEngine;

import org.junit.jupiter.api.Test;

import java.util.HashSet;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class SearchEngineTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    static final InvertedIndex invertedIndex = mock(InvertedIndex.class);

    @Test
    public void ShouldSearchForProperDocs(){
        HashSet<String> listOfWord_old = new HashSet<>();
        listOfWord_old.add("57110");
        HashSet<String> listOfWord_friend = new HashSet<>();
        listOfWord_friend.add("57110");
        HashSet<String> listOfWord_problem = new HashSet<>();
        listOfWord_problem.add("58045");
        HashSet<String> listOfWord_doctor = new HashSet<>();
        listOfWord_doctor.add("59652");
        HashSet<String> listOfWord_remember = new HashSet<>();
        listOfWord_remember.add("58045");

        when(invertedIndex.getResultListByWord("old")).thenReturn(listOfWord_old);
        when(invertedIndex.getResultListByWord("friend")).thenReturn(listOfWord_friend);
        when(invertedIndex.getResultListByWord("problem")).thenReturn(listOfWord_problem);
        when(invertedIndex.getResultListByWord("doctor")).thenReturn(listOfWord_doctor);
        when(invertedIndex.getResultListByWord("remember")).thenReturn(listOfWord_remember);

        SearchEngine searchEngine = new SearchEngine(invertedIndex);

        Set<String> results = searchEngine.getResult("old friend +problem +doctor -remember");
        assertEquals(2, results.size(),"size of result is not equal with actual size");
        assertTrue(results.contains("59652"),"search engine is wrong");
        assertTrue(results.contains("57110"),"search engine is wrong");
    }

}
