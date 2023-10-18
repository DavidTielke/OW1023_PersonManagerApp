namespace DavidTielke.PMA.Data.FileStoring;

public class TextFileReader : ITextFileReader
{
    public string[] Read(string path)
    {
        return File.ReadAllLines(path);
    }
}