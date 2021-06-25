using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using DotNetRocks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetRocks.Services
{
    public class ApiService
    {
        private HttpClient httpClient;
        private string ShowName = "dotnetrocks";
        string baseUrl = "https://pwopclientapi.azurewebsites.net/shows/";

        public ApiService()
        {
            httpClient = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<List<Show>> GetAllShows()
        {
            string Url = ShowName;
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Show>>(response);
        }

        public async Task<int> GetCount()
        {
            string Url = $"{ShowName}/getcount";
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return Convert.ToInt32(response);
        }

        public async Task<List<Show>> GetRange(int FirstShowNumber, int LastShowNumber)
        {
            string Url = $"{ShowName}/{FirstShowNumber}/{LastShowNumber}/getrange";
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Show>>(response);
        }

        public async Task<Show> GetShowWithDetails(int ShowNumber)
        {
            string Url = $"{ShowName}/{ShowNumber}/getwithdetails";
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Show>(response);
        }

        public async Task<ShowDetails> GetShowDetails(int ShowNumber)
        {
            string Url = $"{ShowName}/{ShowNumber}/getdetails";
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShowDetails>(response);
        }

        public async Task<List<int>> GetShowNumbers()
        {
            try
            {
                string Url = $"{ShowName}/getshownumbers";
                var result = await httpClient.GetAsync(Url);
                result.EnsureSuccessStatusCode();
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<int>>(response);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public async Task<List<Show>> GetByShowNumbers(GetByShowNumbersRequest Request)
        {
            try
            {
                var http = new HttpClient();
                var url = baseUrl;
                string json = JsonConvert.SerializeObject(Request);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var result = await http.PostAsync(url, content);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<Show>>(responseBody);
                return items;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }
    }
}