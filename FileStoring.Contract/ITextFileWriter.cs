namespace DavidTielke.PMA.Data.FileStoring;

public interface ITextFileWriter
{
    void Write(string path, string[] text);
}