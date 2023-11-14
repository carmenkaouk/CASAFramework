using CASAFramework.BaseClasses;
using CASAFramework.Interfaces;
using CASAFramework.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASAFramework.Middlewares
{
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
                response.SendResponse();
            }

        }
    }
}
