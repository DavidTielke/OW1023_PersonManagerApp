using DavidTielke.PMA.CrossCutting.DataClasses;

namespace DavidTielke.PMA.Data.DataCsvStoring;

public interface IPersonRepository
{
    IQueryable<Person> Load();
    void Insert(Person person);
}