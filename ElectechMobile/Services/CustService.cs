using ElectechMobile.Model;
using Newtonsoft.Json;
using System.Text;


namespace ElectechMobile.Services
{
    public static class Globals
    {
        public const string BaseUrl = "http://amingomaa-001-site24.dtempurl.com/api/";
    }
    public static class CustService
    {
        private static readonly HttpClient Client = new()
        {
            BaseAddress = new(Globals.BaseUrl)
        };
        public static async Task<bool> Post(CustFolwDTO Body, string? url = null)
        {
            StringContent content = new(JsonConvert.SerializeObject(Body), Encoding.UTF8, "application/json");
            return (await Client.PostAsync("CustFlow/Create".Replace('\\', '/'), content)).IsSuccessStatusCode;
        }
        public static async Task<List<Customer>> GetCustomersByName(string custName)
        {
            var response = await Client.GetAsync($"Customer/GetName/{custName}");;
            return JsonConvert.DeserializeObject<List<Customer>>(await response.Content.ReadAsStringAsync());
        }
    }

}