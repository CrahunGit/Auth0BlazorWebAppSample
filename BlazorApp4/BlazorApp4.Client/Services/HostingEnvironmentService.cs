using Microsoft.JSInterop;

namespace BlazorApp4.Client.Services;

public class HostingEnvironmentService
{
    public bool IsWebAssembly { get; private set; }

    public HostingEnvironmentService(IJSRuntime jsRuntime)
    {
        IsWebAssembly = jsRuntime is IJSInProcessRuntime;
    }

	public string EnvironmentName => IsWebAssembly ? "WebAssembly" : "Server";
}