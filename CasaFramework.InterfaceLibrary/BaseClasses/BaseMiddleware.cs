

namespace CasaFramework.InterfaceLibrary.BaseClasses;

public abstract class BaseMiddleware 
{
    public int Priority { get; }
    public BaseMiddleware Next { get; set; }

    public void SetNext(BaseMiddleware middleware)
    {
        Next = middleware;
    }

    public abstract void Process(Context context);

}