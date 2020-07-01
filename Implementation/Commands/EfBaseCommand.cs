using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public abstract class EfBaseCommand
    {
        protected EfBaseCommand(BlogContext context)
        {
            Context = context;
        }

        protected BlogContext Context { get; }
    }
}
