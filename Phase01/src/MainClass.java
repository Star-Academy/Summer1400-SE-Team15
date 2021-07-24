public class MainClass {
    public static void main(String[] args) {
        FileReader fileReader = new FileReader("EnglishData");
        InvertedIndex invertedIndex = new InvertedIndex(fileReader.getFilesInFolder());

    }
}
