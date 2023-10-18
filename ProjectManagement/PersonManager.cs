using Configuration.Contract;
using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.DataCsvStoring;

namespace DavidTielke.PMA.Logic.PersonManagement;

public class PersonManager : IPersonManager
{
    private readonly IPersonRepository _repository;

    private readonly int AGE_TRESHOLD;

    public PersonManager(IPersonRepository repository, IConfigurator config)
    {
        _repository = repository;
        AGE_TRESHOLD = config.Get<int>("AgeTreshold");
    }

    public IQueryable<Person> GetAdults()
    {
        return _repository.Load().Where(p => p.Age >= AGE_TRESHOLD);
    }

    public IQueryable<Person> GetChildren()
    {
        return _repository.Load().Where(p => p.Age < AGE_TRESHOLD);
    }
}