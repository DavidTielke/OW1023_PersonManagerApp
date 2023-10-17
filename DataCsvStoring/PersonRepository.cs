using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.FileStoring;

namespace DavidTielke.PMA.Data.DataCsvStoring;

public class PersonRepository
{
    private readonly PersonConverter _converter;
    private readonly TextFileReader _reader;
    private readonly TextFileWriter _writer;

    public PersonRepository()
    {
        _reader = new TextFileReader();
        _writer = new TextFileWriter();
        _converter = new PersonConverter();
    }

    public IQueryable<Person> Load()
    {
        var lines = _reader.Read("data.csv");
        var persons = _converter.FromCsv(lines);
        return persons.AsQueryable();
    }

    public void Insert(Person person)
    {
        var lines = _reader.Read("data.csv");
        var newLine = _converter.ToCsv(person);
        var newLines = lines.Append(newLine).ToArray();
        _writer.Write("data.csv", newLines);
    }
}