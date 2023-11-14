﻿using CASAFramework.BaseClasses;
using CASAFramework.Options;

namespace CASAFramework.Middlewares
{
    internal class AuthenticationMiddleware : BaseMiddleware
    {
        private AuthenticationOptionBuilder optionsBuilder;

        public AuthenticationMiddleware(AuthenticationOptionBuilder optionsBuilder)
        {
            this.optionsBuilder = optionsBuilder;
        }

        public override void Process(Context context)
        {
            throw new NotImplementedException();
        }
    }
}