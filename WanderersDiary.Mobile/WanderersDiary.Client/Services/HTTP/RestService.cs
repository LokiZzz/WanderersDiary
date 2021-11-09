using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Client.Services.HTTP
{
    public interface IRestService
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request) where TResponse : class;
    }

    public class RestService : IRestService
    {
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request) where TResponse : class
        {
            try
            {
                using (HttpClient httpClient = CreateUnsecureClient())
                {
                    HttpResponseMessage responseMessage = await httpClient.PostAsync(path, request.GetJsonStringContent());

                    return await responseMessage.ToResponseModelAsync<TResponse>();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private HttpClient CreateUnsecureClient()
        {
            HttpClient client = new HttpClient();

            #if DEBUG
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
            #endif

            return client;
        }
    }
}
