using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

#pragma warning disable CA2012 // Usar ValueTasks corretamente

namespace EficazFramework.Utilities;

public static class JsInterop
{
    public static ValueTask<string> Prompt(this IJSRuntime jsRuntime, string message)
    {
        return jsRuntime.InvokeAsync<string>(
                            "efcoreJsFunctions.showPrompt",
                            message);
    }

    public static void AddClass(this IJSRuntime jsRuntime, string query, string className)
    {
        jsRuntime.InvokeVoidAsync(
                        "efcoreJsFunctions.addclass",
                        query, className);
    }

    public static void AcceptCookie(this IJSRuntime jsRuntime, string cookieName)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.acceptCookieMessage",
                    cookieName);
    }

    public static void ChangeUrl(this IJSRuntime jsRuntime, string url)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.changeUrl",
                    url);
    }

    public static void Click(this IJSRuntime jsRuntime, ElementReference element)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.clickElement",
                    element);
    }

    public static void ClickByID(this IJSRuntime jsRuntime, string elementID)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.clickElementByID",
                    elementID);
    }

    public static void Focus(this IJSRuntime jsRuntime, ElementReference element)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.focusElement",
                    element);
    }

    public static void Focus(this IJSRuntime jsRuntime, string elementID)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.focusElementByID",
                    elementID);
    }

    public static void FocusChild(this IJSRuntime jsRuntime, string parentID)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.focusChildElementByID",
                    parentID);
    }

    public static void FocusChildOf(this IJSRuntime jsRuntime, string parentID, string expectedtype = "input")
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.focusChildOf",
                    parentID, expectedtype);
    }

    public static void Print(this IJSRuntime jsRuntime)
    {
        jsRuntime.InvokeVoidAsync(
            "efcoreJsFunctions.print");
    }


    public static void RemoveClass(this IJSRuntime jsRuntime, string query, string className)
    {
        jsRuntime.InvokeVoidAsync(
                        "efcoreJsFunctions.removeclass",
                        query, className);
    }

    public static void ScrollToBottom(this IJSRuntime jsRuntime, ElementReference element)
    {
        jsRuntime.InvokeVoidAsync(
            "efcoreJsFunctions.scrollToBottom",
            element);
    }

    public static void ScrollToBottomByID(this IJSRuntime jsRuntime, string elementID)
    {
        jsRuntime.InvokeVoidAsync(
            "efcoreJsFunctions.scrollToBottomByID",
            elementID);
    }

    public static void ScrollToBottomBySelector(this IJSRuntime jsRuntime, string selector)
    {
        jsRuntime.InvokeVoidAsync(
            "efcoreJsFunctions.scrollToBottomBySelector",
            selector);
    }

    public static void StartObserve(this IJSRuntime jsRuntime, string query, string intersectingClassName, bool permanent, string? function = null)
    {
        jsRuntime.InvokeVoidAsync(
                        "efcoreJsFunctions.startObserve",
                        query, intersectingClassName, permanent, function);
    }

    public static void StopObserve(this IJSRuntime jsRuntime, string query)
    {
        jsRuntime.InvokeVoidAsync(
                    "efcoreJsFunctions.stopObserve",
                    query);
    }

}
#pragma warning restore CA2012 // Usar ValueTasks corretamente
