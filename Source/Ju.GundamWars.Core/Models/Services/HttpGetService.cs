using System;
using System.Net;


namespace Ju.GundamWars.Models.Services
{

    public class HttpGetService : DisposableBindableBase
    {

        public HttpGetService()
        {
            httpClient = new HttpClient();

            Disposables.Add(httpClient);
        }


        private readonly HttpClient httpClient;


        public bool TryGet(string requestUri, out string result)
        {
            result = "";

            var statusCoode = HttpStatusCode.NotFound;

            try
            {
                using var request = CreateRequest(HttpMethod.Get, requestUri);
                using var response = httpClient.SendAsync(request);
                result = response.Result.Content.ReadAsStringAsync().Result;
                statusCoode = response.Result.StatusCode;
            }
            catch (HttpRequestException ex)
            {
                // UNDONE: 通信失敗のエラー処理
                return false;
            }

            if (statusCoode != HttpStatusCode.OK)
            {
                // UNDONE: レスポンスが200 OK以外の場合のエラー処理
                return false;
            }
            if (string.IsNullOrEmpty(result))
            {
                // UNDONE: レスポンスのボディが空の場合のエラー処理
                return false;
            }

            return true;
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string requestUri)
        {
            var request = new HttpRequestMessage(method, requestUri);
            //request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Charset", "utf-8");
            return request;
        }

    }

}
