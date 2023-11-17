using CasaFramework.MainLibrary;
using CasaFramework.MainLibrary.BaseClasses;
using CasaFramework.MainLibrary.Interfaces;


namespace CasaFramework.MainLibrary.Middlewares;

public class ExceptionHandlingMiddleware : BaseMiddleware
{
    public override void Process(Context context)
    {
        try
        {
            Next.Process(context);
        }
        catch (Exception e)
        {
            IResponse response = ((IResponse)context.Get("Response")); 
            response.SetException(e);
            
        }

    }
}
