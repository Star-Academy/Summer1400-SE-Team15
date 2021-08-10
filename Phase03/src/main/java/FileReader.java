package main.java;

import java.io.File;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;


import static java.lang.System.err;



public class FileReader implements IFileReader {
    private final File folder;
    private final String stopWordsPath;
    private static final String NON_CHAR_REGEX = "\\W+";

    public FileReader(String folderPath , String stopWord){
        folder = new File(folderPath);
        stopWordsPath = stopWord;
    }

    @Override
    public List<FileTuple> getFilesContents() {
        List<FileTuple> filesContent = new ArrayList<>();
        for (final File fileEntry : folder.listFiles()) {
            filesContent.add(new FileTuple(fileEntry.getName(),getContentFromFile(fileEntry)));
        }
        return filesContent;
    }

    @Override
    public List<String> getStopWords(){
        try {
            return Files.readAllLines(Paths.get(stopWordsPath));
        } catch (IOException e) {
            e.printStackTrace();
        }
        return new ArrayList<>();
    }



    @Override
    public String getContentFromFile(File doc) {
        String content = "";

        try {
            content = Files.readString(Path.of(doc.getPath()), StandardCharsets.UTF_8);
        } catch (IOException e) {
            err.println("error in read files");
            e.printStackTrace();
        }

        return getNormalizedString(content);
    }

    private String getNormalizedString(String content) {
        return content.toLowerCase().replaceAll(NON_CHAR_REGEX, " ");
    }

}
