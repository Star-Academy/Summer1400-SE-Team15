package test.java;

import main.java.FileReader;
import main.java.InvertedIndex;
import main.java.SearchEngine;

import org.junit.jupiter.api.Test;

import java.util.HashSet;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

public class SearchEngineTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    @Test
    public void ShouldSearchForProperDocs(){
        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        SearchEngine searchEngine = new SearchEngine(invertedIndex);


        Set<String> results = searchEngine.getResult("poet fool -mother +help");
        assertEquals(2, results.size(),"size of result is not equal with actual size");
        assertTrue(results.contains("59652"),"search engine is wrong");
        assertTrue(results.contains("57110"),"search engine is wrong");
    }

}
