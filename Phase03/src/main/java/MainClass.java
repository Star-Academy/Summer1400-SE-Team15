package main.java;

public class MainClass {

    static final String FOLDER_PATH = "EnglishData";
    static final String STOP_WORDS_PATH = "utilities/stopWords.txt";

    public static void main(String[] args) {

        final IFileReader IFileReader = new FileReader(FOLDER_PATH,STOP_WORDS_PATH);
        final IInvertedIndex IInvertedIndex = new InvertedIndex(IFileReader);
        final ISearchEngine ISearchEngine = new SearchEngine(IInvertedIndex);
        final IView viewConsole = new ViewConsole();
        final InputScanner scanner = new InputScanner(viewConsole, ISearchEngine);

        scanner.ScanInput();
    }
}