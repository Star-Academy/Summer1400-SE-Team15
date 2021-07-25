import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class MainClass {
    public static void main(String[] args) {
        FileReader fileReader = new FileReader("EnglishData");
        InvertedIndex invertedIndex = new InvertedIndex(fileReader.getFilesInFolder());
        SearchEngine searchEngine = new SearchEngine(invertedIndex);

        Set<String> results = searchEngine.getResult("");
        for (String result : results){
            System.out.println(result);
        }

    }
}
