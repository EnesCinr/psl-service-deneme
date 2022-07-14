using System.Net.Http.Headers;

namespace PSL.WebApi
{
    public static class TempHelper
    {
        public static HttpClient ApiClient{ get; set; }
        public static void Initialize()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.BaseAddress = new Uri("http://test-masterapi.povodu.com");
        }
    }
}
