using ElectechMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectechMobile.Services
{
   
    public static class ProductService
    {
        private static readonly HttpClient Client = new();
public static async Task<Category[]> GetCategories(string? url = null)
        {
            string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/Product/GetAllCat";

            // Combine the base URL with the id
            string requestUrl = $"{baseUrl}";
            string result=await Client.GetStringAsync(requestUrl);
            return JsonConvert.DeserializeObject<Category[]>(result);
        }
        public static async Task<Product[]> GetProductByCatId(int id, string? url = null)
        {
            string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/Product/GetByCatId";

            string requestUrl = $"{baseUrl}/{id}";
            string result= await Client.GetStringAsync(requestUrl);
            return JsonConvert.DeserializeObject<Product[]>(result);
        }
        public static async Task<ProductTrans[]> GetProductMotion(int id,DateTime sdate,DateTime edate ,string? url = null)
        {
            string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/Product/GetByDates";

            string requestUrl = $"{baseUrl}/{id}/{sdate}/{edate}";
            string result = await Client.GetStringAsync(requestUrl);
            return JsonConvert.DeserializeObject<ProductTrans[]>(result);
        }

    }
}
