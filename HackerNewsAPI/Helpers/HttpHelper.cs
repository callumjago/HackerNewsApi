using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsAPI.Helpers
{
    public class HttpHelper : IHttpHelper
    {
        #region Fields

        private static readonly HttpClient client = new HttpClient();
        #endregion

        public HttpHelper()
        {

        }

        // Returns a resourse from the requested uri of type T
        public async Task<T> GetAsync<T>(string uri)
        {
            var httpResponse = await client.GetAsync(uri);
            string content = httpResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
