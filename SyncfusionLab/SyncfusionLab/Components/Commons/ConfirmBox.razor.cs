using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Components.Commons
{
    using Microsoft.AspNetCore.Components;
    public class ConfirmBoxBase : ComponentBase
    {
        [Parameter]
        public bool IsVisible { get; set; } = false;
        [Parameter]
        public string Height { get; set; } = "250px";
        [Parameter]
        public string Width { get; set; } = "435px";
        [Parameter]
        public string Title { get; set; } = "通知訊息";
        [Parameter]
        public string Message { get; set; } = "訊息內容";
        [Parameter]
        public EventCallback<bool> Callback { get; set; }
        public async Task OnOKBtnclick()
        {
            await CallCallBack(true);
        }
        public async Task OnCancelBtnclick()
        {
            await CallCallBack(false);
        }

        public async Task CallCallBack(bool action)
        {
            if (Callback.HasDelegate)
                await Callback.InvokeAsync(action);
        }
    }
}
