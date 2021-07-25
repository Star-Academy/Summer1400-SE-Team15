import java.io.File;
import java.util.ArrayList;
import java.util.List;

public class FileReader {
    private ArrayList<File> files;
    final File folder;

    public FileReader(String folderPath){
        files = new ArrayList<>();
        folder = new File(folderPath);
    }

    public List<File> getFilesInFolder() {
        for (final File fileEntry : folder.listFiles()) {
            files.add(fileEntry);
        }
        return files;
    }

}
