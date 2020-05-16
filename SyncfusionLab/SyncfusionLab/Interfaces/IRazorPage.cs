using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Interfaces
{
    public interface IRazorPage
    {
        void NeedRefresh();
        Task NeedInvokeAsync(Action action);
    }
}
