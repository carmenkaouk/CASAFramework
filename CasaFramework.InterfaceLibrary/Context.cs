namespace CasaFramework.MainLibrary;

public class Context
{
    private Dictionary<string, object> _data = new Dictionary<string, object>();

    public void Add(string key, object value)
    {
        _data.Add(key, value);
    }

    public object Get(string key)
    {
        return _data[key];
    }

}