package main.java;

import java.util.*;

public class SearchEngine implements ISearchEngine {
    private final IInvertedIndex invertedIndex;

    public SearchEngine(IInvertedIndex invertedIndex){
        this.invertedIndex = invertedIndex;
    }

    @Override
    public Set<String> getResult(String query){

        Set<String> result = new HashSet<>();
        String modifiedQuery = getModifiedQuery(query);

        final List<String> andList = new ArrayList<>();
        final List<String> orList = new ArrayList<>();
        final List<String> excludeList = new ArrayList<>();

        fillListsByQuery(modifiedQuery, andList, orList, excludeList);

        addAndWordsToResult(result, andList);
        addOrWordsToResult(result, orList);
        removeExcludeWordsFromResult(result, excludeList);

        return result;
    }

    private String getModifiedQuery(String query) {
        return query.toLowerCase();
    }

    private void removeExcludeWordsFromResult(Set<String> result, List<String> excludeList) {
        for (String exclude : excludeList){
            result.removeAll(invertedIndex.getResultListByWord(exclude));
        }
    }

    private void addOrWordsToResult(Set<String> result, List<String> orList) {
        for (String or : orList){
            result.addAll(invertedIndex.getResultListByWord(or));
        }
    }

    private void addAndWordsToResult(Set<String> result, List<String> andList) {
        for (String and : andList){
            if (result.isEmpty()){
                result.addAll(invertedIndex.getResultListByWord(and));
            }else {
                result.retainAll(invertedIndex.getResultListByWord(and));
            }
        }
    }

    private void fillListsByQuery(String query, List<String> andList, List<String> orList, List<String> excludeList) {
        for (String word : getNormalizedString(query)){
            if(word.charAt(0)=='+'){
                orList.add(word.substring(1));
            }else if (word.charAt(0)=='-'){
                excludeList.add(word.substring(1));
            }else {
                andList.add(word);
            }
        }
    }

    private String[] getNormalizedString(String query) {
        return query.split(" ");
    }

}
