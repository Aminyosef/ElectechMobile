﻿using ElectechMobile.Model;
using Newtonsoft.Json;
using System;
using System.Text;
namespace ElectechMobile.Services;
#nullable enable
public static class ApiService<T> where T : class
{  
    public const string BaseUrl = "http://amingomaa-001-site24.dtempurl.com/api/";
    private static readonly HttpClient Client = new()
    {
        BaseAddress = new(BaseUrl)
    };
    public static async Task<T[]> GetAll(string? url = null)
    {
        string result = await Client.GetStringAsync(Path.Combine(url ?? Path.Combine(typeof(T).Name, nameof(GetAll))).Replace('\\', '/'));
        return JsonConvert.DeserializeObject<T[]>(result)!;
    }
    public static async Task<T> GetById(int Id, string? url = null)
    {
        string result = await Client.GetStringAsync(Path.Combine(url ?? Path.Combine(typeof(T).Name, nameof(GetById)), Id.ToString()).Replace('\\', '/'));
        return JsonConvert.DeserializeObject<T>(result)!;
    }
    public static async Task<bool> Post(T Body, string? url = null)
    {
        StringContent content = new(JsonConvert.SerializeObject(Body), Encoding.UTF8, "application/json");
        return (await Client.PostAsync(Path.Combine(url ?? typeof(T).Name).Replace('\\', '/'), content)).IsSuccessStatusCode;
    }
    public static async Task<bool> Put(int Id, T Body, string? url = null)
    {
        StringContent content = new(JsonConvert.SerializeObject(Body), Encoding.UTF8, "application/json");
        return (await Client.PutAsync(Path.Combine(url ?? typeof(T).Name, $"?id={Id}").Replace('\\', '/'), content)).IsSuccessStatusCode;
    }
    public static async Task<bool> Delete(int Id, string? url = null) =>
        (await Client.DeleteAsync(Path.Combine(url ?? typeof(T).Name, $"?id={Id}").Replace('\\', '/'))).IsSuccessStatusCode;
    public static async Task<T[]> GetByCustId(int Id, string? url = null)
    {
        string result = await Client.GetStringAsync(Path.Combine(url ?? typeof(T).Name, nameof(GetByCustId), Id.ToString()).Replace('\\', '/'));
        return JsonConvert.DeserializeObject<T[]>(result)!;
    }
    public static async Task<CustomerFlow[]> GetFolwByCustId(int id, string? url = null)
    {
        // Set the default URL if no custom URL is provided
        string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/Custflow/GetFolwByCustId";

        // Combine the base URL with the id
        string requestUrl = $"{baseUrl}/{id}";

        try
        {
            // Make the HTTP GET request
            string result = await Client.GetStringAsync(requestUrl);
            Console.WriteLine($"API Response: {result}");

            // Deserialize the JSON response into an array of CustFollw objects
            return JsonConvert.DeserializeObject<CustomerFlow[]>(result)!;
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Array.Empty<CustomerFlow>(); // Return an empty array on error
        }
    }
    public static async Task<Customer[]> GetFolwByEngId(int id, string? url = null)
    {
        // Set the default URL if no custom URL is provided
        string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/Custflow/GetFollowSinceOneMonth";

        // Combine the base URL with the id
        string requestUrl = $"{baseUrl}/{id}";

        try
        {
            // Make the HTTP GET request
            string result = await Client.GetStringAsync(requestUrl);
            Console.WriteLine($"API Response: {result}");

            // Deserialize the JSON response into an array of CustFollw objects
            return JsonConvert.DeserializeObject<Customer[]>(result)!;
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Array.Empty<Customer>(); // Return an empty array on error
        }
    }
    public static async Task<CustomerFlow[]> GetFirstFolwByCustId(int id, string? url = null)
    {
        // Set the default URL if no custom URL is provided
        string baseUrl = url ?? "http://amingomaa-001-site24.dtempurl.com/api/Custflow/GetFirstFolwByCustId";

        // Combine the base URL with the id
        string requestUrl = $"{baseUrl}/{id}";

        try
        {
            // Make the HTTP GET request
            string result = await Client.GetStringAsync(requestUrl);
            Console.WriteLine($"API Response: {result}");

            // Deserialize the JSON response into an array of CustFollw objects
            return JsonConvert.DeserializeObject<CustomerFlow[]>(result)!;
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Array.Empty<CustomerFlow>(); // Return an empty array on error
        }
    }

}
#nullable disable