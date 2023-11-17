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

        public async Task<ServiceResponse<Movie>> CreateMovieAsync(Movie movie)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.MovieEndpoint.GetAllMoviesEndpoint, movie);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteMovieAsync(int id)
        {
            try {
                var response = await _httpClient.DeleteAsync(_appSettings.BaseAPIUrl + _appSettings.MovieEndpoint.GetAllMoviesEndpoint + id);
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
                return result;
            }
            catch (Exception)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
            
        }

        public async Task<ServiceResponse<List<Movie>>> GetMoviesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_appSettings.BaseAPIUrl + _appSettings.MovieEndpoint.GetAllMoviesEndpoint);
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Movie>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Movie>>>();

                return result;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Movie>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
        }

        public async Task<ServiceResponse<Movie>> GetMovieByIdAsync(int id)
        {
            try {
                var response = await _httpClient.GetAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<Movie>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();

                return result;
            }
             catch (Exception)
            {
                return new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
        }

        public async Task<ServiceResponse<Movie>> UpdateMovieAsync(Movie movie)
        {
            var response = await _httpClient.PutAsJsonAsync(_appSettings.MovieEndpoint.GetAllMoviesEndpoint, movie);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();
            return result;
        }

        public async Task<ServiceResponse<List<Movie>>> SearchMoviesAsync(string text)
        {

            try
            {
                string searchUrl = string.IsNullOrWhiteSpace(text) ? "" : $"/{text}";
                var response = await _httpClient.GetAsync(_appSettings.MovieEndpoint.SearchMoviesEndpoint + searchUrl);
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Movie>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Movie>>>();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new ServiceResponse<List<Movie>>
                {
                    Success = false,
                    Message = "Network error"
                };
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