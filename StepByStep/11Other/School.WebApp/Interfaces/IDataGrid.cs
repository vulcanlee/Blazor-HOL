using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Interfaces
{
    public interface IDataGrid
    {
        void RefreshGrid();
        bool GridIsExist();
        Task InvokeGridAsync(string actionName);
    }
}
