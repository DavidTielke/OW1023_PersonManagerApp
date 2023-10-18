namespace Configuration.Contract;

public interface IConfigurator
{
    T Get<T>(string key);
    void Set(string key, object value);
}