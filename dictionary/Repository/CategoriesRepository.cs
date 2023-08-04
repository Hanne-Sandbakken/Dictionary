using dictionary.Contracts;
using dictionary.Data;
using Microsoft.EntityFrameworkCore;

namespace dictionary.Repository
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        private readonly DictionaryDbContext _context;

        public CategoriesRepository(DictionaryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetDetails(int id)
        {
            return await _context.Categories.Include(query => query.Words)
                .FirstOrDefaultAsync(query => query.Id == id);
        }
    }
}
