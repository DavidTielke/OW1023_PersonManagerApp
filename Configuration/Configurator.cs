using Configuration.Contract;

namespace Configuration;

public class Configurator : IConfigurator
{
    private readonly Dictionary<string, object> _items;

    public Configurator()
    {
        _items = new Dictionary<string, object>();
    }

    public T Get<T>(string key)
    {
        return (T)_items[key];
    }

    public void Set(string key, object value)
    {
        _items[key] = value;
    }
}