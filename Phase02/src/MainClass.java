import java.util.Scanner;
import java.util.Set;

public class MainClass {
    public static void main(String[] args) {
        final String FOLDER_PATH = "EnglishData";
        final String STOP_WORDS_PATH = "utilities/stopWords.txt";

        FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        SearchEngine searchEngine = new SearchEngine(invertedIndex);
        InputScanner scanner = new InputScanner(searchEngine);

        scanner.ScanInput();
    }
}
