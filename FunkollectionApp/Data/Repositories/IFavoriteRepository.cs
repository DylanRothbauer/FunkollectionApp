using FunkollectionApp.Models;

namespace FunkollectionApp.Data.Repositories
{
    public interface IFavoriteRepository : IRepository<Pop>
    {
        Task<bool> IsFavoriteAsync(string userId, int popId);
        Task AddFavoriteAsync(string userId, int popId);
        Task RemoveFavoriteAsync(string userId, int popId);
        Task<IEnumerable<Pop>> GetUserFavoritesAsync(string userId);
    }
}
