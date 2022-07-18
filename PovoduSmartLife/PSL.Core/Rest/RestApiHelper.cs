using Newtonsoft.Json;
using PSL.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Rest
{
    public static class RestApiHelper
    {
        public static async Task<string> Get(string url)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                client.BaseAddress = new Uri(url);
                //client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
                var response = client.GetAsync(url);
                response.Wait();
                return await response.Result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Get With query string
        public static async Task<IDataResult<string>> GetWithQuery(string url, Dictionary<string, string> queryStrings = null, Dictionary<string, string> headers = null)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                AddQueryStrings(ref url, queryStrings);

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                client.BaseAddress = new Uri(url);
                AddHeaders(client, headers);

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"[CUSTOM MESSAGE] URL: {url} Status Code: {response.StatusCode} Content: {content}");

                return new SuccessDataResult<string>(data: content);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(message: ex.Message);
            }
        }

        public static async Task<HttpResponseMessage> Post(string url, string param)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                var httpContent = new StringContent(param, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(url, httpContent);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<HttpResponseMessage> Post<T>(string url, T instance) where T : class, new()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                var httpContent = new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(url, httpContent);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<HttpResponseMessage> Post<T>(string url, T instance, string username, string password) where T : class, new()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                var httpContent = new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Basic {0}", Convert.ToBase64String(Encoding.GetEncoding(RestConstants.Encoding).GetBytes(username + ":" + password))));

                var response = await client.PostAsync(url, httpContent);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<HttpResponseMessage> PostAsJson<T>(string url, T instance, string username, string password) where T : class, new()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Basic {0}", Convert.ToBase64String(Encoding.GetEncoding(RestConstants.Encoding).GetBytes(username + ":" + password))));

                var response = await client.PostAsJsonAsync(url, instance);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> Post<T>(string url, T instance, string token) where T : class, new()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                var httpContent = new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));

                var response = client.PostAsync(url, httpContent);
                response.Wait();
                return await response.Result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> Delete(string url, string instance)//, string token)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                var httpContent = new StringContent(instance, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
                var response = client.PostAsync(url, httpContent);
                response.Wait();
                return await response.Result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static async Task<IResult> Put(string url, string jsonParam, Dictionary<string, string> queryStrings = null)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };

                AddQueryStrings(ref url, queryStrings);

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using var client = new HttpClient(httpClientHandler);
                var httpContent = new StringContent(jsonParam, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsync(url, httpContent);
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"PUT/{url} -> {content}");

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void AddQueryStrings(ref string url, Dictionary<string, string> queryStrings)
        {
            if (queryStrings == null)
                return;

            var firstQuery = true;
            foreach (var queryString in queryStrings)
            {
                url += $"{(firstQuery ? "?" : "&")}{queryString.Key}={queryString.Value}";
                firstQuery = false;
            }
        }
        private static void AddHeaders(HttpClient client, Dictionary<string, string> headers)
        {
            if (headers == null)
                return;

            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }
}
