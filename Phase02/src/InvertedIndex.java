import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static java.lang.System.err;

public class InvertedIndex {

    private HashMap<String, HashSet<String>> dataHashMap;

    public InvertedIndex(FileReader fileReader){
        dataHashMap = new HashMap<>();
        tokenize(fileReader.getFilesContents(),fileReader.getStopWords());
    }


    private void tokenize(List<FileTuple> docs,List<String> stopWords){

        for(FileTuple doc : docs) {
            ArrayList<String> allWords =
                    Stream
                            .of(getNormalizedString(doc.getData()))
                            .collect(Collectors.toCollection(ArrayList<String>::new));
            allWords.removeAll(stopWords);

            for (String word : allWords){
                if (dataHashMap.containsKey(word)){
                    dataHashMap.get(word).add(doc.getName());
                }else {
                    HashSet<String> hashSet = new HashSet();
                    hashSet.add(doc.getName());
                    dataHashMap.put(word,hashSet);
                }
            }
        }
    }

    private String[] getNormalizedString(String doc) {
        return Arrays.stream(doc.split(" ")).filter(e -> e.trim().length() > 0).toArray(String[]::new);
    }

    public HashSet<String> getResultListByWord(String word){
        if (!dataHashMap.containsKey(word)) {
            return new HashSet<>();
        }
        return dataHashMap.get(word);
    }
}
