using FunkollectionApp.Data;
using FunkollectionApp.Data.Repositories;
using FunkollectionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FunkollectionApp.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository repository)
        {
            _favoriteRepository = repository;
        }

        public async Task AddFavoriteAsync(string userId, int popId)
        {
            await _favoriteRepository.AddFavoriteAsync(userId, popId);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pop>> GetUserFavoritesAsync(string userId)
        {
            return await _favoriteRepository.GetUserFavoritesAsync(userId);
            //throw new NotImplementedException();
        }

        public async Task<bool> IsFavoriteAsync(string userId, int popId)
        {
            return await _favoriteRepository.IsFavoriteAsync(userId, popId);
            //throw new NotImplementedException();
        }

        public async Task RemoveFavoriteAsync(string userId, int popId)
        {
            await _favoriteRepository.RemoveFavoriteAsync(userId, popId);
            //throw new NotImplementedException();
        }
    }
}
