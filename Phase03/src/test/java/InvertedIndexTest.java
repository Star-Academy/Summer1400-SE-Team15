package test.java;

import main.java.FileReader;
import main.java.InvertedIndex;

import org.junit.jupiter.api.Test;


import java.util.HashSet;

import static org.junit.jupiter.api.Assertions.*;

public class InvertedIndexTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    @Test
    public void ShouldTokenizeASample(){
        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        HashSet<String> result = invertedIndex.getResultListByWord("poet");
        assertEquals(true, result.contains("59652"),"inverted index is wrong");

    }

}
