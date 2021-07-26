import java.util.Scanner;
import java.util.Set;

public class MainClass {
    public static void main(String[] args) {
        final String folderPath = "EnglishData";
        final String stopWordsPath = "utilities/stopWords.txt";

        FileReader fileReader = new FileReader(folderPath,stopWordsPath);
        InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        SearchEngine searchEngine = new SearchEngine(invertedIndex);

        Scanner scanner = new Scanner(System.in);

        while (true){
            String query = scanner.nextLine();
            if(query.equals("--exit")) break;
            Set<String> results = searchEngine.getResult(query);
            if(results.isEmpty()){
                System.out.println("No Result");
                continue;
            }
            for (String result : results){
                System.out.println(result);
            }
        }
        scanner.close();
    }
}
