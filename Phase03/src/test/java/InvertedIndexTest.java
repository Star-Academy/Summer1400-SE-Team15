package test.java;

import main.java.FileReader;
import main.java.FileTuple;
import main.java.IView;
import main.java.InvertedIndex;

import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.stubbing.Answer;


import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class InvertedIndexTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    static final FileReader fileReader = mock(FileReader.class);

    @Test
    public void ShouldTokenizeASample(){
        List<FileTuple> filesContent = new ArrayList<>();
        List<String> stopWords ;

        filesContent.add(new FileTuple("57110","I have a 42 yr old male friend"));
        filesContent.add(new FileTuple("58043",">This wouldn't happen to be the same thing as chiggers, would it>"));
        filesContent.add(new FileTuple("59652","This is not an unusual practice if the doctor is also member of a nudist colony--Sir, I admit your gen'ral rulThat every poet"));

        stopWords = Arrays.asList("i", "have", "a", "this", "wouldn't", "to", "be", "the", "as", "is", "not", "an", "if", "of");

        when(fileReader.getFilesContents()).thenReturn(filesContent);
        when(fileReader.getStopWords()).thenReturn(stopWords);

        InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        HashSet<String> result = invertedIndex.getResultListByWord("poet");
        assertTrue(result.contains("59652"), "inverted index is wrong");

    }

}
