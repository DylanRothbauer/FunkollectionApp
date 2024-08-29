using FunkollectionApp.Data.Repositories;
using FunkollectionApp.Models;
using Microsoft.CodeAnalysis.CSharp;

namespace FunkollectionApp.Services
{
    public class PopService : IPopService
    {
        private readonly IPopRepository _popRepository;
        public PopService(IPopRepository repository)
        {
            _popRepository = repository;
        }
        public async Task AddEntityAsync(Pop entity)
        {
            await _popRepository.AddAsync(entity);
            //throw new NotImplementedException();
        }

        public async Task DeleteEntityAsync(int id)
        {
            await _popRepository.DeleteAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pop>> GetAllEntitiesAsync()
        {
            return await _popRepository.GetAllAsync();
            //throw new NotImplementedException();
        }

        public async Task<Pop> GetEntityByIdAsync(int id)
        {
            return await _popRepository.GetByIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pop>> GetPopsByUserAsync(string userId)
        {
            return await _popRepository.GetPopsByUserAsync(userId);
            //throw new NotImplementedException();
        }

        public async Task UpdateEntityAsync(Pop entity)
        {
            await _popRepository.UpdateAsync(entity);
            //throw new NotImplementedException();
        }
    }
}
