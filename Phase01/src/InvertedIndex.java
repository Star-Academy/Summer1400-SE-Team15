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

    private List<String> stopWords;
    private HashMap<String, HashSet<String>> dataHashMap;

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
                    dataHashMap.get(word).add(doc.getName());
                }else {
                    HashSet<String> hashSet = new HashSet();
                    hashSet.add(doc.getName());
                    dataHashMap.put(word,hashSet);
                }
            }
        }
//        for (Map.Entry<String, HashSet<String>> entry : dataHashMap.entrySet()) {
//            System.out.println();
//            System.out.print(entry.getKey() + "  :  ");
//            for (String f : entry.getValue()){
//                System.out.print(f + " , ");
//            }
//
//        }
        return;
    }

//    public HashMap<String, HashSet<File>> getDataHashMap(){
//        return dataHashMap;
//    }
    public HashSet<String> getResultListByWord(String word){
        if (!dataHashMap.containsKey(word)) {
            System.out.println("word not found...");
            return new HashSet<>();
        }
        return dataHashMap.get(word);
    }
}
