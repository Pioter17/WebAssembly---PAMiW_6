using blazorapp.Shared.Models;

namespace blazorapp.Shared.Services.DirectorService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetDirectorAsync();
    }
}