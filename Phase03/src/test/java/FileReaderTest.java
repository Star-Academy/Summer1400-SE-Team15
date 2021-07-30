package test.java;

import main.java.FileReader;
import main.java.FileTuple;

import org.junit.jupiter.api.Test;


import java.io.File;
import java.io.IOException;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

public class FileReaderTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";
    static final String WRONG_STOP_WORDS_PATH = "thisIsAWrongPath";
    static final String WRONG_FOLDER_PATH = "thisIsAWrongPath";

    @Test
    public void ShouldCreateData(){
        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        List<FileTuple> filesContent = fileReader.getFilesContents();
        assertEquals(filesContent.get(0).getName(),"57110","test file is wrong");
        assertEquals(filesContent.get(0).getData(),"i have a 42 yr old male friend misdiagnosed as havin osteopporosis for two years who recently found out that hi illness is the rare gaucher s disease gaucher s disease symptoms include brittle bones he lost 9 inches off his hieght enlarged liver and spleen interna bleeding and fatigue all the time the problem in type 1 i attributed to a genetic mutation where there is a lack of th enzyme glucocerebroside in macrophages so the cells swell up this will eventually cause deathenyzme replacement therapy has been successfully developed an approved by the fda in the last few years so that those patient administered with this drug called ceredase report a remarkabl improvement in their condition ceredase which is manufacture by biotech biggy company genzyme costs the patient 380 00 per year gaucher s disease has justifyably been called the mos expensive disease in the world need infoi have researched gaucher s disease at the library but am relyin on netlanders to provide me with any additional information news stories report people you know with this diseas ideas articles about genzyme corp how to get a hold o enough money to buy some programs available to help wit costs basically any help you can offethanks so very muchdeborah","created data is wrong");
    }

    @Test
    public void ShouldCreateStopWordsList(){
        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        List<String> stopWords = fileReader.getStopWords();
        assertEquals(stopWords.get(0),"a","wrong reading from stop words");
    }

    @Test
    public void ShouldReturnEmptyList(){
        FileReader fileReader = new FileReader(FOLDER_PATH,WRONG_STOP_WORDS_PATH);
        List<String> stopWords = fileReader.getStopWords();
        assertTrue(stopWords.isEmpty());
    }

    @Test
    public void ShouldReturnEmptyStringAndPrintError(){
        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);

            String content = fileReader.getContentFromFile(new File(WRONG_FOLDER_PATH));

        assertEquals(content,"","content is not empty");
    }




}
