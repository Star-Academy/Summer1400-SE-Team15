import java.util.Scanner;
import java.util.Set;

public class MainClass {

    static final String FOLDER_PATH = "EnglishData";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    public static void main(String[] args) {

        final FileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        final InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        final SearchEngine searchEngine = new SearchEngine(invertedIndex);
        final InputScanner scanner = new InputScanner(searchEngine);

        scanner.ScanInput();
    }
}
