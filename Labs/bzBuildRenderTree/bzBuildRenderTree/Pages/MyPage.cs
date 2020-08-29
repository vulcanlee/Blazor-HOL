using bzBuildRenderTree.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzBuildRenderTree.Pages
{
    [Route("/MyPage")]
    [Layout(typeof(MainLayout))]
    public class MyPage : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
            #region 底下的程式碼，將是從編譯器產生出來的 Counter 元件複製過來的
            __builder.AddMarkupContent(0, "<h1>Counter</h1>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Current count: ");
            __builder.AddContent(3, currentCount);
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-primary");
            __builder.AddAttribute(7, "onclick"
                , Microsoft.AspNetCore.Components.EventCallback.Factory
                .Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, IncrementCount));
            __builder.AddContent(8, "Click me");
            __builder.CloseElement();
            #endregion

            #region 這裡宣告一個按鈕，沒做甚麼事情，但會觸發 BuildRenderTree 再度執行
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-danger");
            __builder.AddAttribute(7, "onclick"
                , Microsoft.AspNetCore.Components.EventCallback.Factory
                .Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, EmptyCount));
            __builder.AddContent(8, "不會做任何事情");
            __builder.CloseElement();
            #endregion
        }
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }
        private void EmptyCount()
        {
            Console.WriteLine($"Nothing , only Click");
        }
    }
}
