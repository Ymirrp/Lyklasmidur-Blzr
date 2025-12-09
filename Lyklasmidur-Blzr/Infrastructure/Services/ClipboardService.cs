using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Lyklasmidur_Blzr.Infrastructure.Services
{
    public sealed class ClipboardService(IJSRuntime jsRuntime)
    {
        private readonly IJSRuntime _jsRuntime = jsRuntime;

        public ValueTask WriteTextAsync(string text)
            => _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);

        public ValueTask<string> ReadTextAsync()
            => _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
    }
}
