using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class LogSearch : BaseSearch
    {
        public string UseCaseName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
    
}
