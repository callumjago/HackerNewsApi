using System.Threading.Tasks;

namespace HackerNewsAPI.Helpers
{
    public interface IHttpHelper
    {
        // Returns a resourse from the requested uri of type T
        public Task<T> GetAsync<T>(string uri);
    }
}
