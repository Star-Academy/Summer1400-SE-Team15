package main.java;

import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;



public class InvertedIndex implements IInvertedIndex {

    final private HashMap<String, HashSet<String>> dataHashMap;

    public InvertedIndex(IFileReader fileReader){
        dataHashMap = tokenize(fileReader.getFilesContents(), fileReader.getStopWords());
    }


    private HashMap<String,HashSet<String>> tokenize(List<FileTuple> docs,List<String> stopWords){

        HashMap<String,HashSet<String>> outputMap = new HashMap<>();

        for(FileTuple doc : docs) {
            ArrayList<String> allWords = Stream.of(getNormalizedString(doc.getData()))
                                                .collect(Collectors.toCollection(ArrayList<String>::new));
            allWords.removeAll(stopWords);

            addWordsToMap(outputMap, doc, allWords);
        }
        return outputMap;
    }

    private void addWordsToMap(HashMap<String,HashSet<String>> outputMap, FileTuple doc, ArrayList<String> allWords) {
        for (String word : allWords){
            if (!outputMap.containsKey(word)) {
                outputMap.put(word, new HashSet<>());
            }
            outputMap.get(word).add(doc.getName());
        }
    }

    private String[] getNormalizedString(String doc) {
        return Arrays.stream(doc.split(" "))
                .filter(e -> e.trim().length() > 0)
                .toArray(String[]::new);
    }

    @Override
    public HashSet<String> getResultListByWord(String word){
        return dataHashMap.getOrDefault(word,new HashSet<>());
    }
}
