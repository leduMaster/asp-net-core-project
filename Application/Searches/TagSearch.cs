using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
     public class TagSearch : BaseSearch
    {
        public string Keyword { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
