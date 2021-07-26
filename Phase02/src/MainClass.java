import java.util.Scanner;
import java.util.Set;

public class MainClass {
    public static void main(String[] args) {
        FileReader fileReader = new FileReader("EnglishData");
        InvertedIndex invertedIndex = new InvertedIndex(fileReader.getFilesInFolder());
        SearchEngine searchEngine = new SearchEngine(invertedIndex);

        Scanner scanner = new Scanner(System.in);
        while (true){
            Set<String> results = searchEngine.getResult(scanner.nextLine());
            for (String result : results){
                System.out.println(result);
            }
        }
    }
}
