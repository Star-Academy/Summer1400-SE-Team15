import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static java.lang.System.err;

public class InvertedIndex {

    private HashMap<String, HashSet<String>> dataHashMap;

    public InvertedIndex(FileReader _fileReader){
        dataHashMap = new HashMap<>();
        tokenize(_fileReader.getFilesContents(),_fileReader.getStopWords());
    }


    private void tokenize(List<Tuple<String,String>> docs,List<String> stopWords){

        for(Tuple<String,String> doc : docs) {
            ArrayList<String> allWords =
                    Stream
                            .of(doc.getY().split(" "))
                            .collect(Collectors.toCollection(ArrayList<String>::new));
            allWords.removeAll(stopWords);

            for (String word : allWords){
                if (word.isEmpty()) continue;
                if (dataHashMap.containsKey(word)){
                    dataHashMap.get(word).add(doc.getX());
                }else {
                    HashSet<String> hashSet = new HashSet();
                    hashSet.add(doc.getX());
                    dataHashMap.put(word,hashSet);
                }
            }
        }
    }

    public HashSet<String> getResultListByWord(String word){
        if (!dataHashMap.containsKey(word)) {
            System.out.println("word not found...");
            return new HashSet<>();
        }
        return dataHashMap.get(word);
    }
}
