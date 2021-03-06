package test.java;

import main.java.FileReader;
import main.java.FileTuple;

import main.java.IFileReader;
import org.junit.jupiter.api.Test;


import java.io.File;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

public class FileReaderTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";
    static final String WRONG_STOP_WORDS_PATH = "thisIsAWrongPath";
    static final String WRONG_FOLDER_PATH = "thisIsAWrongPath";

    @Test
    public void ShouldCreateData(){
        IFileReader IFileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        List<FileTuple> filesContent = IFileReader.getFilesContents();
        FileTuple temp = null;
        for (FileTuple file : filesContent){
            if (file.getName().equals("57110")){
                temp = file;
                break;
            }
        }
        assertNotNull(temp,"test file is wrong");
        assertEquals("i have a 42 yr old male friend", temp.getData(),"created data is wrong");
    }

    @Test
    public void ShouldCreateStopWordsList(){
        IFileReader IFileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        List<String> stopWords = IFileReader.getStopWords();
        assertEquals("a", stopWords.get(0),"wrong reading from stop words");
    }

    @Test
    public void ShouldReturnEmptyList(){
        IFileReader IFileReader = new FileReader(FOLDER_PATH,WRONG_STOP_WORDS_PATH);
        List<String> stopWords = IFileReader.getStopWords();
        assertTrue(stopWords.isEmpty());
    }

    @Test
    public void ShouldReturnEmptyStringAndPrintError(){
        IFileReader IFileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);

            String content = IFileReader.getContentFromFile(new File(WRONG_FOLDER_PATH));

        assertEquals("", content,"content is not empty");
    }




}
