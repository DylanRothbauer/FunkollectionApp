using FunkollectionApp.Models;
using System.Xml;

namespace FunkollectionApp.Services
{
    public interface IPopService
    {
        Task<IEnumerable<Pop>> GetAllEntitiesAsync();
        Task<Pop> GetEntityByIdAsync(int id);
        Task AddEntityAsync(Pop entity);
        Task UpdateEntityAsync(Pop entity);
        Task DeleteEntityAsync(int id);

        // New method to get Pops by User ID
        Task<IEnumerable<Pop>> GetPopsByUserAsync(string userId);

        Task<Dictionary<string, int>> GetUserPopsByCategoryAsync(string userId);
    }
}
