using CasaFramework.InterfaceLibrary;
using CasaFramework.InterfaceLibrary.BaseClasses;
using CasaFramework.InterfaceLibrary.Interfaces;


namespace CasaFramework.InterfaceLibrary.Middlewares;

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
