using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityAllreadyExists : Exception
    {
        public EntityAllreadyExists(string entityType) : base(entityType + " already exists.") { }
    }
}
