using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.DataCsvStoring;

namespace DavidTielke.PMA.Logic.PersonManagement;

public class PersonManager : IPersonManager
{
    private readonly IPersonRepository _repository;

    public PersonManager(IPersonRepository repository)
    {
        _repository = repository;
    }

    public IQueryable<Person> GetAdults()
    {
        return _repository.Load().Where(p => p.Age >= 18);
    }

    public IQueryable<Person> GetChildren()
    {
        return _repository.Load().Where(p => p.Age < 18);
    }
}