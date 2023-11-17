using blazorapp.Shared.Models;

namespace blazorapp.Shared.Services.MovieService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetMoviesAsync();

        Task<ServiceResponse<Movie>> UpdateMoviesAsync(Movie movie);

        Task<ServiceResponse<bool>> DeleteMoviesAsync(int id);

        Task<ServiceResponse<Movie>> CreateMoviesAsync(Movie movie);

        Task<ServiceResponse<Movie>> GetMovieByIdAsync(int id);

        Task<ServiceResponse<List<Movie>>> SearchMoviessAsync(string text);
    }
}