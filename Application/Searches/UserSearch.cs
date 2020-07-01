using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class UserSearch : BaseSearch
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
