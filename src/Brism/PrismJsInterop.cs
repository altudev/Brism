using Microsoft.JSInterop;

namespace Brism;

public class PrismJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public PrismJsInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Brism/prismInterop.js").AsTask());
    }

    public async ValueTask HighlightAsync()
    {
        var module = await moduleTask.Value;

        await module.InvokeVoidAsync("highlightAll");
    }


    public async ValueTask DisposeAsync()
    {
        if (moduleTask != null && moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;

            try
            {
                await module.DisposeAsync();
            }
            catch { }
        }
    }
}