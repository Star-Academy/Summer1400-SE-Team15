package test.java;

import main.java.FileReader;
import main.java.FileTuple;
import org.junit.Test;



import java.util.List;

import static org.junit.Assert.assertEquals;

public class FileReaderTest {

    static final String FOLDER_PATH = "EnglishDataTest";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    @Test
    public void testCreatedData(){
        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        List<FileTuple> filesContent = fileReader.getFilesContents();
        assertEquals("test file is wrong",filesContent.get(0).getName(),"59652");
        assertEquals("created data is wrong",filesContent.get(0).getData(),"this is not an unusual practice if the doctor is also member of a nudist colony sir i admit your gen ral rulthat every poet is a foolbut you yourself may serve to show itthat every fool is not a poet a pop");
    }

}
