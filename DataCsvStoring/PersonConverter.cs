using DavidTielke.PMA.CrossCutting.DataClasses;

namespace DavidTielke.PMA.Data.DataCsvStoring;

public class PersonConverter
{
    public IQueryable<Person> FromCsv(string[] csvContent)
    {
        return csvContent.Select(l => l.Split(","))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            }).AsQueryable();
    }

    public string ToCsv(Person person)
    {
        return $"{person.Id},{person.Name},{person.Age}";
    }
}