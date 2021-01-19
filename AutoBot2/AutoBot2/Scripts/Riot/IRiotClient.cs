using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoBot2.Scripts.Riot
{
    public delegate void LeagueClosedHandler();

    interface IRiotClient
    {
        event LeagueClosedHandler LeagueClosed;
        Task<HttpResponseMessage> UsingApiEventHttpMessage(HttpMethod method, string endpoint, object data = null);
        Task<JObject> UsingApiEventJobject(HttpMethod method, string endpoint, object data = null);
    }

    public enum HttpMethod
    {
        Get,
        Post,
        Put,
        Delete
    }
}
