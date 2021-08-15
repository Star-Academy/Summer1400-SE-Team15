namespace SearchEngineEfCore
{
    public class FileTuple
    {
        public string DocName { get; set; }
        public string DocContent { get; set; }

        public FileTuple(string docName, string docContent)
        {
            DocName = docName;
            DocContent = docContent;
        }
    }
}