using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.FileStoring;

namespace DavidTielke.PMA.Data.DataCsvStoring;

public class PersonRepository : IPersonRepository
{
    private readonly IPersonConverter _converter;
    private readonly ITextFileReader _reader;
    private readonly ITextFileWriter _writer;

    public PersonRepository(IPersonConverter converter,
        ITextFileReader reader,
        ITextFileWriter writer)
    {
        _converter = converter;
        _reader = reader;
        _writer = writer;
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