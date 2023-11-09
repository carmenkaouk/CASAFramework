namespace CASAFramework;

public abstract class BaseMiddleware
{
    public int Priority { get; }
    public Type Prerequisite {  get; }  
    public BaseMiddleware Next { get; set; }

    public void SetNext(BaseMiddleware middleware)
    {
        Next = middleware;
    }

    public abstract Context Process(Context context);

}