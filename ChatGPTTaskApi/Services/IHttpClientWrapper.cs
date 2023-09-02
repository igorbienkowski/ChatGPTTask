namespace ChatGPTTaskApi.Services;

public interface IHttpClientWrapper
{
    Task<string> GetStringAsync(string requestUri);
}