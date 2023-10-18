using DavidTielke.PMA.Data.DataCsvStoring;
using DavidTielke.PMA.Data.FileStoring;
using DavidTielke.PMA.Logic.PersonManagement;
using Ninject;

namespace Mappings;

public class KernelFactory
{
    public IKernel Create()
    {
        var kernel = new StandardKernel();

        kernel.Bind<IPersonManager>().To<PersonManager>();
        kernel.Bind<IPersonRepository>().To<PersonRepository>();
        kernel.Bind<IPersonConverter>().To<PersonConverter>();
        kernel.Bind<ITextFileReader>().To<TextFileReader>();
        kernel.Bind<ITextFileWriter>().To<TextFileWriter>();

        return kernel;
    }
}