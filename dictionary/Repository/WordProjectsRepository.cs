using dictionary.Contracts;
using dictionary.Data;
using Microsoft.EntityFrameworkCore;

namespace dictionary.Repository
{
    public class WordProjectsRepository : GenericRepository<WordProject>, IWordProjectsRepository
    {
        private readonly DictionaryDbContext _context;

        public WordProjectsRepository(DictionaryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WordProject> GetDetails(int id)
        {
            return await _context.WordProjects.Include(wp => wp.Word)
                                              .ThenInclude(w => w.WordClass)
                                              .Include(wp => wp.Project)
                                              .FirstOrDefaultAsync(wp => wp.Id == id);
        }
    }
}
