using ElectechMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectechMobile.Services
{
    public static class Salservice
    {
        private static readonly HttpClient Client = new();
        public static async Task<sal[]> GetAll(string? url = null)
        {
            // Set the default URL if no custom URL is provided
            string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/sal/getall";

            // Combine the base URL with the id
            string requestUrl = $"{baseUrl}";

            try
            {
                // Make the HTTP GET request
                string result = await Client.GetStringAsync(requestUrl);
                Console.WriteLine($"API Response: {result}");

                // Deserialize the JSON response into an array of CustFollw objects
                return JsonConvert.DeserializeObject<sal[]>(result)!;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Array.Empty<sal>(); // Return an empty array on error
            }
        }
        public static async Task<SaleDet[]> GetSalId(int id, string? url = null)
        {
            // Set the default URL if no custom URL is provided
            string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/Sal/GetSal";

            // Combine the base URL with the id
            string requestUrl = $"{baseUrl}/{id}";

            try
            {
                // Make the HTTP GET request
                string result = await Client.GetStringAsync(requestUrl);
                Console.WriteLine($"API Response: {result}");

                // Deserialize the JSON response into an array of CustFollw objects
                return JsonConvert.DeserializeObject<SaleDet[]>(result)!;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Array.Empty<SaleDet>(); // Return an empty array on error
            }
        }

    }
}
