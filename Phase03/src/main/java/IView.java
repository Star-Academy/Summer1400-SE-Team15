package main.java;

import java.util.Set;

public interface IView {
    String Scan();
    void Print(Set<String> output);
    void Close();
}
