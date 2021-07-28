package main.java;

import java.util.Set;

public class InputScanner {
    final private SearchEngine searchEngine;
    final private java.util.Scanner scanner;

    public InputScanner(SearchEngine searchEngine){
        scanner = new java.util.Scanner(System.in);
        this.searchEngine = searchEngine;
    }
    public void ScanInput(){
        while (true){
            String query = scanner.nextLine();
            if(query.equals("--exit")) break;
            Set<String> results = searchEngine.getResult(query);
            if(results.isEmpty()){
                System.out.println("No Result");
                continue;
            }
            for (String result : results){
                System.out.println(result);
            }
        }
        scanner.close();
    }
}
