using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Client.Services.HTTP
{
    public static class RestExtensions
    {
        public static StringContent GetJsonStringContent<TModel>(this TModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static async Task<TModel> ToResponseModelAsync<TModel>(this HttpResponseMessage httpResponseMessage) where TModel : class
        {
            string responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TModel>(responseString);
        }
    }
}
