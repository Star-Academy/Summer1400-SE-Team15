package main.java;

import java.util.Set;

public class InputScanner {
    final private ISearchEngine searchEngine;
    final private IView console;

    public InputScanner(IView viewConsole, ISearchEngine searchEngine){
        this.console = viewConsole;
        this.searchEngine = searchEngine;
    }
    public void ScanInput(){
        while (true){
            String query = console.Scan();
            if(query.equals("--exit")) break;
            Set<String> results = searchEngine.getResult(query);
            console.Print(results);
        }
        console.Close();
    }
}
