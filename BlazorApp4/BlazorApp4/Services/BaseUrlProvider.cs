namespace BlazorApp4.Services;

public class BaseUrlProvider
{
    public string BaseUrl { get; private set; }

    public void SetBaseUrl(string baseUrl)
    {
        BaseUrl = baseUrl;
    }
}
