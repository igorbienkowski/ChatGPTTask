namespace ChatGPTTaskApi.Services;

public class HttpClientWrapper : IHttpClientWrapper
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<string> GetStringAsync(string requestUri)
    {
        return await _httpClient.GetStringAsync(requestUri);
    }
}