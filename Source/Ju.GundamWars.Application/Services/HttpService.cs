using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Services;

public class HttpService(HttpClient httpClient, ILogger<HttpService> logger)
{

    public string GetString(string uriString)
    {
        try
        {
            return httpClient.GetStringAsync(uriString).Result;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "{message}", ex.Message);
            return string.Empty;
        }
    }

    public bool TryDownloadFile(string uriString, string filePath)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(uriString));
            using var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            if (response.IsSuccessStatusCode)
            {
                using var content = response.Content;
                using var stream = content.ReadAsStreamAsync().Result;
                using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                stream.CopyTo(fileStream);
                fileStream.Flush();
                return true;
            }
            logger.LogWarning("StatusCode: {message}", response.StatusCode);
            return false;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "{message}", ex.Message);
            return false;
        }
    }

}
