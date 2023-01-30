using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Utilities;

[ExcludeFromCodeCoverage]
public static class JsInterop
{
    public static ValueTask<string> Prompt(this IJSRuntime jsRuntime, string message)
    {
        return jsRuntime.InvokeAsync<string>(
                            "EfJsFunctions.showPrompt",
                            message);
    }

    public static void AcceptCookie(this IJSRuntime jsRuntime, string cookieName)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.acceptCookieMessage",
                    cookieName);
    }

    public static void AddClass(this IJSRuntime jsRuntime, string query, string className)
    {
        jsRuntime.InvokeVoidAsync(
                        "EfJsFunctions.addclass",
                        query, className);
    }

    public static void ChangeUrl(this IJSRuntime jsRuntime, string url)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.changeUrl",
                    url);
    }

    public static void Click(this IJSRuntime jsRuntime, ElementReference element)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.clickElement",
                    element);
    }

    public static void ClickByID(this IJSRuntime jsRuntime, string elementID)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.clickElementByID",
                    elementID);
    }

    public static void Focus(this IJSRuntime jsRuntime, ElementReference element)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.focusElement",
                    element);
    }

    public static void Focus(this IJSRuntime jsRuntime, string elementID)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.focusElementByID",
                    elementID);
    }

    public static void FocusChild(this IJSRuntime jsRuntime, string parentID)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.focusChildElementByID",
                    parentID);
    }

    public static void FocusChildOf(this IJSRuntime jsRuntime, string parentID, string expectedtype = "input")
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.focusChildOf",
                    parentID, expectedtype);
    }

    public static void Print(this IJSRuntime jsRuntime)
    {
        jsRuntime.InvokeVoidAsync(
            "EfJsFunctions.print");
    }

    public static void RemoveClass(this IJSRuntime jsRuntime, string query, string className)
    {
        jsRuntime.InvokeVoidAsync(
                        "EfJsFunctions.removeclass",
                        query, className);
    }

    public static void SetDragImage(this IJSRuntime jsRuntime, object evt)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.setDragImage",
                    evt);
    }

    public static void ScrollToBottom(this IJSRuntime jsRuntime, ElementReference element)
    {
        jsRuntime.InvokeVoidAsync(
            "EfJsFunctions.scrollToBottom",
            element);
    }

    public static void ScrollToBottomByID(this IJSRuntime jsRuntime, string elementID)
    {
        jsRuntime.InvokeVoidAsync(
            "EfJsFunctions.scrollToBottomByID",
            elementID);
    }

    public static void ScrollToBottomBySelector(this IJSRuntime jsRuntime, string selector)
    {
        jsRuntime.InvokeVoidAsync(
            "EfJsFunctions.scrollToBottomBySelector",
            selector);
    }

    public static void StartObserve(this IJSRuntime jsRuntime, string query, string intersectingClassName, bool permanent, string? function = null, string? targetQuery = null)
    {
        jsRuntime.InvokeVoidAsync(
                        "EfJsFunctions.startObserve",
                        query, intersectingClassName, permanent, function, targetQuery);
    }

    public static void StopObserve(this IJSRuntime jsRuntime, string query)
    {
        jsRuntime.InvokeVoidAsync(
                    "EfJsFunctions.stopObserve",
                    query);
    }

}
