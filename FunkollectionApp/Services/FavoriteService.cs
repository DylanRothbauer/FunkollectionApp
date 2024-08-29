using FunkollectionApp.Data;
using FunkollectionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FunkollectionApp.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsFavoriteAsync(string userId, int popId)
        {
            return await _context.UserFavorites
                .AnyAsync(uf => uf.UserId == userId && uf.PopId == popId);
        }

        public async Task AddFavoriteAsync(string userId, int popId)
        {
            if (!await IsFavoriteAsync(userId, popId))
            {
                var favorite = new UserFavorite
                {
                    UserId = userId,
                    PopId = popId
                };
                _context.UserFavorites.Add(favorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFavoriteAsync(string userId, int popId)
        {
            var favorite = await _context.UserFavorites
                .FirstOrDefaultAsync(uf => uf.UserId == userId && uf.PopId == popId);

            if (favorite != null)
            {
                _context.UserFavorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pop>> GetUserFavoritesAsync(string userId)
        {
            return await _context.UserFavorites
                .Where(uf => uf.UserId == userId)
                .Select(uf => uf.Pop)
                .ToListAsync();
        }
    }
}
