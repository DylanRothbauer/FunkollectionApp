using FunkollectionApp.Models;

namespace FunkollectionApp.Services
{
    public interface IFavoriteService
    {
        Task<bool> IsFavoriteAsync(string userId, int popId);
        Task AddFavoriteAsync(string userId, int popId);
        Task RemoveFavoriteAsync(string userId, int popId);
        Task<IEnumerable<Pop>> GetUserFavoritesAsync(string userId);
    }
}
