using DavidTielke.PMA.CrossCutting.DataClasses;

namespace DavidTielke.PMA.Data.DataCsvStoring;

public interface IPersonConverter
{
    IQueryable<Person> FromCsv(string[] csvContent);
    string ToCsv(Person person);
}