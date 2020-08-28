using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Interfaces
{
    public interface IRazorPage
    {
        void NeedRefresh();
        Task NeedInvokeAsync(Action action);
    }
}
