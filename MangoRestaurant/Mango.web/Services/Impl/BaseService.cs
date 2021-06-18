using mango.web.Configuration;
using mango.web.Services.Contracts;
using mango.web.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace mango.web.Services.Impl
{
    public abstract class BaseService : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public async Task<T> SendAsync<T>(ApiRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient("MangoApi");
                client.DefaultRequestHeaders.Clear();
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                message.RequestUri = new Uri(request.Url);
                if (request.Body != null)
                {
                    message.Content = new StringContent
                        (JsonConvert.SerializeObject(request.Body), System.Text.Encoding.UTF8, "application/json");
                }
                switch (request.Type)
                {
                    case RequestType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case RequestType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case RequestType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case RequestType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;
                }
                HttpResponseMessage response = await client.SendAsync(message);
                var deserializedResponse = JsonConvert.DeserializeObject<Response<T>>(await response.Content.ReadAsStringAsync());
                if (deserializedResponse.ErrorMessages.Count > 0)
                {
                    throw new ErrorResponse(deserializedResponse.ErrorMessages);
                }
                return deserializedResponse.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
