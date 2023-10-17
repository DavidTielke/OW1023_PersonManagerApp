using DavidTielke.PMA.Logic.PersonManagement;

namespace DavidTielke.PMA.UI.ConsoleClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var manager = new PersonManager();

        var adults = manager.GetAdults().ToList();
        Console.WriteLine($"### Erwachsene ({adults.Count}) ###");
        adults.ForEach(a => Console.WriteLine(a.Name));

        var children = manager.GetChildren().ToList();
        Console.WriteLine($"### Kinder ({children.Count}) ###");
        children.ForEach(c => Console.WriteLine(c.Name));
    }
}