using FunkollectionApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunkollectionApp.Data.Repositories
{
    public class PopRepository : Repository<Pop>, IPopRepository
    {
        private readonly ApplicationDbContext _context;

        public PopRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Method to get pops by user ID
        public async Task<IEnumerable<Pop>> GetPopsByUserAsync(string userId)
        {
            // Assuming there's a UserId property in the Pop entity
            return await _context.Pops
                                 .Where(pop => pop.UserId == userId)
                                 .ToListAsync();
        }
    }
}
