using FunkollectionApp.Data.Repositories;
using FunkollectionApp.Models;

namespace FunkollectionApp.Services
{
    public class PopService : IPopService
    {
        private readonly IRepository<Pop> _popRepository;
        public PopService(IRepository<Pop> repository)
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

        public async Task UpdateEntityAsync(Pop entity)
        {
            await _popRepository.UpdateAsync(entity);
            //throw new NotImplementedException();
        }
    }
}
