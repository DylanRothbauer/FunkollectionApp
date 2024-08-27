using FunkollectionApp.Models;
namespace FunkollectionApp.Data.Repositories
{
    public class PopRepository : Repository<Pop>
    {
        public PopRepository(ApplicationDbContext context)
        : base(context)
        {
        }

        // Add specific methods for Pop here if needed
    }
}
