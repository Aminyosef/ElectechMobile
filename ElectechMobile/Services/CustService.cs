using ElectechMobile.Model;
using Newtonsoft.Json;
using System.Text;


namespace ElectechMobile.Services
{
    public static class CustService
    {
        private static readonly HttpClient Client = new();
        private const string BaseUrl = "http://amingomaa-001-site24.dtempurl.com/api/CustFlow/Create";
        public static async Task<bool> Post(CustFolwDTO Body, string? url = null)
        {
            StringContent content = new(JsonConvert.SerializeObject(Body), Encoding.UTF8, "application/json");
            return (await Client.PostAsync(BaseUrl.Replace('\\', '/'), content)).IsSuccessStatusCode;
        }
    }
}
