package main.java;

import java.util.Set;

public class InputScanner {
    final private ISearchEngine ISearchEngine;
    final private IView console;

    public InputScanner(IView viewConsole, ISearchEngine ISearchEngine){
        this.console = viewConsole;
        this.ISearchEngine = ISearchEngine;
    }
    public void ScanInput(){
        while (true){
            String query = console.Scan();
            if(query.equals("--exit")) break;
            Set<String> results = ISearchEngine.getResult(query);
            console.Print(results);
        }
        console.Close();
    }
}
