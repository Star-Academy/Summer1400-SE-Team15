package main.java;

import java.io.File;
import java.util.List;

public interface IFileReader {
    List<FileTuple> getFilesContents();

    List<String> getStopWords();

    String getContentFromFile(File doc);
}
