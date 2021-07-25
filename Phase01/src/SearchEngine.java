import java.util.*;

public class SearchEngine {
    private InvertedIndex invertedIndex;

    public SearchEngine(InvertedIndex invertedIndex){
        this.invertedIndex = invertedIndex;
    }

    public Set<String> getResult(String query){
        query = query.toLowerCase();

        Set<String> result = new HashSet<>();

        List<String> andList = new ArrayList<>();
        List<String> orList = new ArrayList<>();
        List<String> excludeList = new ArrayList<>();

        for (String word : query.split(" ")){
            if(word.charAt(0)=='+'){
                orList.add(word.substring(1));
            }else if (word.charAt(0)=='-'){
                excludeList.add(word.substring(1));
            }else {
                andList.add(word);
            }
        }

        for (String and : andList){
            if (result.isEmpty()){
                result.addAll(invertedIndex.getResultListByWord(and));
            }else {
                result.retainAll(invertedIndex.getResultListByWord(and));
            }
        }

        for (String or : orList){
            result.addAll(invertedIndex.getResultListByWord(or));
        }

        for (String exclude : excludeList){
            result.removeAll(invertedIndex.getResultListByWord(exclude));
        }

        if (result.isEmpty()){
            System.out.println("result not found");
        }
        return result;
    }

}
