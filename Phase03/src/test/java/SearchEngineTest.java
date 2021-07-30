package test.java;

import main.java.FileReader;
import main.java.InvertedIndex;
import main.java.SearchEngine;
import org.junit.Test;


import java.util.Set;

import static org.junit.Assert.assertEquals;

public class SearchEngineTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    @Test
    public void testSearchEngine(){
        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        SearchEngine searchEngine = new SearchEngine(invertedIndex);
        Set<String> results = searchEngine.getResult("poet");
        assertEquals("search engine is wrong",results.contains("59652"),true);
    }

}