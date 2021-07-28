public class FileTuple {
    private String name;
    private String data;

    public FileTuple(String name, String data) {
        this.name = name;
        this.data = data;
    }

    public String getName(){
        return name;
    }

    public String getData(){
        return data;
    }
}