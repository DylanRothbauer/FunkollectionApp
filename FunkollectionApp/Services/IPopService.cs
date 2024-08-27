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
    }
}
