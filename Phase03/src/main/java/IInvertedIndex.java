package main.java;

import java.util.HashSet;

public interface IInvertedIndex {
    HashSet<String> getResultListByWord(String word);
}
