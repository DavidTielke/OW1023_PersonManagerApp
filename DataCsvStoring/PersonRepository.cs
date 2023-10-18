using Configuration.Contract;
using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.FileStoring;

namespace DavidTielke.PMA.Data.DataCsvStoring;

public class PersonRepository : IPersonRepository
{
    private readonly IConfigurator _config;
    private readonly IPersonConverter _converter;
    private readonly ITextFileReader _reader;
    private readonly ITextFileWriter _writer;

    private readonly string CSV_FILE_PATH;

    public PersonRepository(IPersonConverter converter,
        ITextFileReader reader,
        ITextFileWriter writer,
        IConfigurator config)
    {
        _converter = converter;
        _reader = reader;
        _writer = writer;
        _config = config;

        CSV_FILE_PATH = config.Get<string>("CsvFileName");
    }

    public IQueryable<Person> Load()
    {
        var lines = _reader.Read(CSV_FILE_PATH);
        var persons = _converter.FromCsv(lines);
        return persons.AsQueryable();
    }

    public void Insert(Person person)
    {
        var lines = _reader.Read(CSV_FILE_PATH);
        var newLine = _converter.ToCsv(person);
        var newLines = lines.Append(newLine).ToArray();
        _writer.Write(CSV_FILE_PATH, newLines);
    }
}