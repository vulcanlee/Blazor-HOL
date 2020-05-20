using MatBlazor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Adaptors
{
    public class DataManagerRequest
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; }
        public int PageSize { get; set; } = 5;
        public int CurrentPage { get; set; } = 0;
        public int RecordLength { get; set; }
        public List<MatPageSizeOption> PageSizeOptions { get; set; } = new List<MatPageSizeOption>();

        public bool RequiresCounts { get; set; } = true;

        public List<string> Group { get; set; }

        public List<string> Select { get; set; }

        public List<Sort> Sorted { get; set; }
        public List<SearchFilter> Search { get; set; }

        public DataManagerRequest()
        {
            ChangePageSize(PageSize);
        }
        public void ChangePageSize(int pageSize)
        {
            PageSize = pageSize;
            PageSizeOptions.Clear();
            PageSizeOptions.Add(new MatPageSizeOption(PageSize));
        }
        public void GoFirstPage()
        {
            Skip = 0;
            CurrentPage = 1;
            Take = PageSize;
        }
        public void GoNextPage()
        {
            Skip = CurrentPage * PageSize;
            CurrentPage++;
        }
        public void GotoPage(int page)
        {
            CurrentPage = page;
            Skip = (CurrentPage-1) * PageSize;
        }

        public void GoPrevPage()
        {
            CurrentPage--;
            Skip = CurrentPage * PageSize;
        }

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

    public class DataResult<T>
    {
        public IEnumerable<T> Result { get; set; }

        public int Count { get; set; }
    }

}
