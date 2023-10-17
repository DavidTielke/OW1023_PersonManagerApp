namespace DavidTielke.PMA.Data.FileStoring;

public class TextFileReader
{
    public string[] Read(string path)
    {
        return File.ReadAllLines(path);
    }
}