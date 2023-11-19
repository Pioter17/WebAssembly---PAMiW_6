using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using blazorapp.Shared.Services;
using blazorapp.Shared.Configuration;
using blazorapp.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace blazorapp.Shared.Services.DirectorService
{
    public class DirectorService
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public DirectorService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }
        public async Task<List<Director>> GetDirectorsAsync(int page)
        {
            try
            {
                var response = await _httpClient.GetAsync(_appSettings.BaseAPIUrl + _appSettings.DirectorEndpoint.GetAllDirectorsEndpoint);
                if (!response.IsSuccessStatusCode){
                    return [];
                }
                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<List<Director>>();
                List<Director> finalResult = new List<Director>();
                for (int i = 10*(page-1); i < page*10 && i < result.Count; i++)
                {
                    finalResult.Add(result[i]);
                }
                return finalResult;
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}