using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

class RiotClientManager
{
    public delegate void LeagueClosedHandler();
    public event LeagueClosedHandler LeagueClosed; // 클라이언트 닫을 때 

    private HttpClient httpClient = null;

    public RiotClientManager()
    {
    }

    // 웹 클라 연결
    public bool Connect()
    {
        try
        {
            ConnectInit();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                                            "Basic"
                                            , Convert.ToBase64String(Encoding.ASCII.GetBytes($"riot:{ClientData.ToKen}")));
            httpClient.BaseAddress = new Uri(ClientData.ApiUrl);

            ClientData.clientProcess.EnableRaisingEvents = true;
            ClientData.clientProcess.Exited += ClientProcess_Exited;

            return true;
        }
        catch
        {
            Console.WriteLine("Connect 오류");

            return false;
        }
    }

    // Client 핸들 초기화
    private void ConnectInit()
    {
        this.httpClient = null;

        var handler = new HttpClientHandler();
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.ServerCertificateCustomValidationCallback =
            (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            };

        httpClient = new HttpClient(handler);
    }

    /// <summary>
    /// API 메시지를 JObject로 리턴
    /// </summary>
    /// <param name="method">Get,Post,Put,Delete 타입</param>
    /// <param name="endpoint">API 주소</param>
    /// <param name="data">보낼 데이터</param>
    public async Task<JObject> UsingApiEventJObject(string method, string endpoint, object data = null)
    {
        var response = await UsingApiEventHttpMessage(method, endpoint, data);
        var responseJson = JObject.Parse(await response.Content.ReadAsStringAsync());
        return responseJson;
    }

    /// <summary>
    /// API 메시지를 HttpResponseMessage로 리턴
    /// </summary>
    /// <param name="method">Get,Post,Put,Delete 타입</param>
    /// <param name="endpoint">API 주소</param>
    /// <param name="data">보낼 데이터</param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> UsingApiEventHttpMessage(string method, string endpoint, object data = null)
    {
        var json = data == null ? "" : JsonConvert.SerializeObject(data);
        switch (method)
        {
            case "Get":
                return await httpClient.GetAsync(endpoint);
            case "Post":
                return await httpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
            case "Put":
                return await httpClient.PutAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
            case "Delete":
                return await httpClient.DeleteAsync(endpoint);
            default:
                throw new Exception("Unsupported HTTP method");
        }
    }

    // 롤 클라이언트 종료 이벤트
    private void ClientProcess_Exited(object sender, EventArgs e)
    {
        LeagueClosed();
    }
}