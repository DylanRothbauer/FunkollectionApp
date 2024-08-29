using FunkollectionApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunkollectionApp.Data.Repositories
{
    public interface IPopRepository : IRepository<Pop>
    {
        Task<IEnumerable<Pop>> GetPopsByUserAsync(string userId); // New method to get pops by user ID
    }
}
