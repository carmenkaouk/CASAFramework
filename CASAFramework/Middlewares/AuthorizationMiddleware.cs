using CASAFramework.BaseClasses;
using CASAFramework.Options;

namespace CASAFramework.Middlewares
{
    internal class AuthorizationMiddleware : BaseMiddleware
    {
        private AuthorizationOptionBuilder optionsBuilder;

        public AuthorizationMiddleware(AuthorizationOptionBuilder optionsBuilder)
        {
            this.optionsBuilder = optionsBuilder;
        }

        public override Context Process(Context context)
        {
            throw new NotImplementedException();
        }
    }
}