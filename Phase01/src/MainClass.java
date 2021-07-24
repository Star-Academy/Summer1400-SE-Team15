public class MainClass {
    public static void main(String[] args) {
        FileReader fileReader = new FileReader("C:\\Users\\naser farajzade\\Desktop\\EnglishData2");
        InvertedIndex invertedIndex = new InvertedIndex(fileReader.getFilesInFolder());

    }
}
