using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class Pagination<T> where T : class
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
    }
}
