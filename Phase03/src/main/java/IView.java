package main.java;

import java.util.Set;

public interface IView {
    public String Scan();
    public void Print(Set<String> output);
    public void Close();
}
