namespace DavidTielke.PMA.Data.FileStoring;

public interface ITextFileReader
{
    string[] Read(string path);
}