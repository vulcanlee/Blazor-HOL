using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Adaptors
{
    public class DataManagerRequest
    {
        public int Skip { get; set; }

        public int Take { get; set; }

        public bool RequiresCounts { get; set; }

        public List<string> Group { get; set; }

        public List<string> Select { get; set; }

        public List<Sort> Sorted { get; set; }

        public List<SearchFilter> Search { get; set; }

    }
    public class Sort
    {
        public string Name { get; set; }

        public string Direction { get; set; }
    }

    public class SearchFilter
    {
        public List<string> Fields { get; set; }

        public string Key { get; set; }

        public string Operator { get; set; }

        public bool IgnoreCase { get; set; }
    }
}
