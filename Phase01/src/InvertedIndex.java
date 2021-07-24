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
            this.stopWords = Files.readAllLines(Paths.get("utilities\\stopWords.txt"));
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
                if (dataHashMap.containsKey(word)){
                    dataHashMap.get(word).add(doc);
                }else {
                    HashSet hashSet = new HashSet<File>();
                    hashSet.add(doc);
                    dataHashMap.put(word,hashSet);
                }
            }

//            System.out.println(doc.getName());
//            System.out.println();
//            System.out.println(result);
//            System.out.println("_________________________________________");
            List<String> list = new ArrayList<>();
            for (String entry : dataHashMap.keySet()) {
//                System.out.print(entry.getKey()+ " : ");
//                for (File file : entry.getValue()){
//                    System.out.print(file.getName()+" ");
//                }
//                System.out.println();
                if (!entry.isEmpty())
                    list.add(entry);
                //System.out.println(entry.getKey());
            }
            list.sort(new Comparator<String>() {
                @Override
                public int compare(String s, String t1) {
                    return s.compareTo(t1);
                }
            });

            for (String s : list){
                System.out.println(s);
                for(byte b : s.getBytes()){
                    System.out.print(b);
                }

//                System.out.println(s);
//                System.out.println(s.length());
//                System.out.println((int)s.charAt(0));
                System.out.println("-------");
            }


        }
    }
}
