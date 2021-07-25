import java.io.File;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static java.lang.System.err;

public class InvertedIndex {

    List<String> stopWords;
    HashMap<String, HashSet<File>> dataHashMap;

    public InvertedIndex(List<File> docs){
        dataHashMap = new HashMap<>();

        try {
            this.stopWords = Files.readAllLines(Paths.get("utilities/stopWords.txt"));
        } catch (IOException e) {
            e.printStackTrace();
        }

        tokenize(docs);
    }

    private String getContentFromFile(File doc) {
        String content = "";

        try {
          content = Files.readString(Path.of(doc.getPath()), StandardCharsets.UTF_8);
        } catch (IOException e) {
            err.println("error in read files");
            e.printStackTrace();
        }

        return content.toLowerCase().replaceAll("\\W+", " ");
    }

    private void tokenize(List<File> docs){

        for(File doc : docs) {
            ArrayList<String> allWords =
                    Stream
                            .of(getContentFromFile(doc).split(" "))
                            .collect(Collectors.toCollection(ArrayList<String>::new));
            allWords.removeAll(stopWords);

            for (String word : allWords){
                if (word == "") continue;
                if (dataHashMap.containsKey(word)){
                    dataHashMap.get(word).add(doc);
                }else {
                    HashSet hashSet = new HashSet<File>();
                    hashSet.add(doc);
                    dataHashMap.put(word,hashSet);
                }
            }
        }
        for (Map.Entry<String, HashSet<File>> entry : dataHashMap.entrySet()) {
            System.out.println();
            System.out.print(entry.getKey() + "  :  ");
            for (File f : entry.getValue()){
                System.out.print(f.getName() + " , ");
            }

        }
    }
}
