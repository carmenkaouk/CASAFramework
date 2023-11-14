namespace CASAFramework.BaseClasses;

public abstract class BaseMiddleware :IComparable<BaseMiddleware>
{
    public int Priority { get; }
    public BaseMiddleware Next { get; set; }

    public void SetNext(BaseMiddleware middleware)
    {
        Next = middleware;
    }

    public abstract Context Process(Context context);

    public int CompareTo(BaseMiddleware other)
    {
        return (Priority - other.Priority); 
    }
}