import java.util.*;

public class SearchEngine {
    private final InvertedIndex invertedIndex;

    public SearchEngine(InvertedIndex invertedIndex){
        this.invertedIndex = invertedIndex;
    }

    public Set<String> getResult(String query){

        Set<String> result = new HashSet<>();
        String modifiedQuery = query.toLowerCase();

        List<String> andList = new ArrayList<>();
        List<String> orList = new ArrayList<>();
        List<String> excludeList = new ArrayList<>();

        fillListsByQuery(modifiedQuery, andList, orList, excludeList);

        addAndWordsToResult(result, andList);
        addOrWordsToResult(result, orList);
        removeExcludeWordsFromResult(result, excludeList);

        return result;
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
