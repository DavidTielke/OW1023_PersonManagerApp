namespace DavidTielke.PMA.Data.FileStoring;

public class TextFileWriter : ITextFileWriter
{
    public void Write(string path, string[] text)
    {
        File.WriteAllLines(path, text);
    }
}