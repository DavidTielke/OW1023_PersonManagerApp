using DavidTielke.PMA.Data.DataCsvStoring;
using DavidTielke.PMA.Data.FileStoring;
using DavidTielke.PMA.Logic.PersonManagement;
using Ninject;

namespace DavidTielke.PMA.UI.ConsoleClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var kernel = new StandardKernel();

        kernel.Bind<IPersonManager>().To<PersonManager>();
        kernel.Bind<IPersonRepository>().To<PersonRepository>();
        kernel.Bind<IPersonConverter>().To<PersonConverter>();
        kernel.Bind<ITextFileReader>().To<TextFileReader>();
        kernel.Bind<ITextFileWriter>().To<TextFileWriter>();

        var manager = kernel.Get<IPersonManager>();

        var adults = manager.GetAdults().ToList();
        Console.WriteLine($"### Erwachsene ({adults.Count}) ###");
        adults.ForEach(a => Console.WriteLine(a.Name));

        var children = manager.GetChildren().ToList();
        Console.WriteLine($"### Kinder ({children.Count}) ###");
        children.ForEach(c => Console.WriteLine(c.Name));
    }
}