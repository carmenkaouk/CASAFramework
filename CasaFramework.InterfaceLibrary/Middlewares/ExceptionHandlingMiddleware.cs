using CasaFramework.InterfaceLibrary;
using CasaFramework.InterfaceLibrary.BaseClasses;
using CasaFramework.InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
