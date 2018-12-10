
//单例模式
public abstract class CSharpSingletion<T> where T : new()
{
    private static T _instance;
    private static readonly object _lockObj = new object();
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lockObj)
                {
                    if (_instance == null)
                        _instance = new T();
                }
            }
            return _instance;
        }
    }
}