package main.java;

import java.util.Set;

public class ViewConsole implements IView{
    final private java.util.Scanner scanner;


    public ViewConsole(){
        scanner = new java.util.Scanner(System.in);
    }

    @Override
    public String Scan() {
        return scanner.nextLine();
    }

    @Override
    public void Print(Set<String> output) {
        if(output.isEmpty()){
            System.out.println("No Result");
        }
        for (String result : output){
            System.out.println(result);
        }
    }

    @Override
    public void Close() {
        scanner.close();
    }
}
