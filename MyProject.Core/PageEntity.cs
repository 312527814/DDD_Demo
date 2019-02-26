using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Core
{
    public class PageEntity<T>
    {
        public IEnumerable<T> List { get; set; }

        public int Count { get; set; }


    }

}
