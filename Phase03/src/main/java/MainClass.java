package main.java;

public class MainClass {

    static final String FOLDER_PATH = "EnglishData";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    public static void main(String[] args) {

        final IFileReader fileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        final IInvertedIndex invertedIndex = new InvertedIndex(fileReader);
        final ISearchEngine searchEngine = new SearchEngine(invertedIndex);
        final IView viewConsole = new ViewConsole();
        final InputScanner scanner = new InputScanner(viewConsole, searchEngine);

        scanner.ScanInput();
    }
}