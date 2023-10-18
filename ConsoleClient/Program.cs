using DavidTielke.PMA.Data.DataCsvStoring;
using DavidTielke.PMA.Data.FileStoring;
using DavidTielke.PMA.Logic.PersonManagement;

namespace DavidTielke.PMA.UI.ConsoleClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var writer = new TextFileWriter();
        var reader = new TextFileReader();
        var converter = new PersonConverter();
        var repository = new PersonRepository(converter, reader, writer);
        var manager = new PersonManager(repository);

        var adults = manager.GetAdults().ToList();
        Console.WriteLine($"### Erwachsene ({adults.Count}) ###");
        adults.ForEach(a => Console.WriteLine(a.Name));

        var children = manager.GetChildren().ToList();
        Console.WriteLine($"### Kinder ({children.Count}) ###");
        children.ForEach(c => Console.WriteLine(c.Name));
    }
}