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

namespace blazorapp.Shared.Services.MovieService
{
    public class MovieService
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public MovieService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<Movie> CreateMovieAsync(MovieDTO movie)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.BaseAPIUrl + _appSettings.MovieEndpoint.GetAllMoviesEndpoint, movie);
            var result = await response.Content.ReadFromJsonAsync<Movie>();
            return result;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            try {
                var response = await _httpClient.DeleteAsync(_appSettings.BaseAPIUrl + _appSettings.MovieEndpoint.GetAllMoviesEndpoint + '/' + id);
                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<bool>();
                return result;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<List<Movie>> GetMoviesAsync(int page)
        {
            try
            {
                var response = await _httpClient.GetAsync(_appSettings.BaseAPIUrl + _appSettings.MovieEndpoint.GetAllMoviesEndpoint);
                if (!response.IsSuccessStatusCode){
                    return [];
                }
                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<List<Movie>>();
                List<Movie> finalResult = new List<Movie>();
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

        public async Task<Movie> UpdateMovieAsync(int id, MovieDTO movie)
        {
            var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseAPIUrl + _appSettings.MovieEndpoint.GetAllMoviesEndpoint + '/' + id, movie);
            var result = await response.Content.ReadFromJsonAsync<Movie>();
            return result;
        }

        public async Task<List<Movie>> SearchMoviesAsync(string text, int page)
        {

            try
            {
                string searchUrl = string.IsNullOrWhiteSpace(text) ? "" : $"name={text}";
                var response = await _httpClient.GetAsync(_appSettings.BaseAPIUrl + _appSettings.MovieEndpoint.SearchMoviesEndpoint + searchUrl);
                if (!response.IsSuccessStatusCode)
                    return [];

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<List<Movie>>();

                List<Movie> finalResult = new List<Movie>();
                for (int i = 10*(page-1); i < page*10 && i < result.Count; i++)
                {
                    finalResult.Add(result[i]);
                }
                return finalResult;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        public Task<ServiceResponse<Movie>> UpdateMoviesAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteMoviesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Movie>> CreateMoviesAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Movie>>> SearchMoviessAsync(string text)
        {
            throw new NotImplementedException();
        }
    }
}