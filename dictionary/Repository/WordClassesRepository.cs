using dictionary.Contracts;
using dictionary.Data;
using Microsoft.EntityFrameworkCore;

namespace dictionary.Repository
{
    public class WordClassesRepository : GenericRepository<WordClass>, IWordClassRepository
    {
        private readonly IWordRepositoy _context;

        public WordClassesRepository(IWordRepositoy context) : base(context)
        {
            _context = context;
        }

        public async Task<WordClass> GetDetails(int id)
        {
            return await _context.WordClasses.Include(query => query.Words)
                .FirstOrDefaultAsync(query => query.Id == id);
        }
    }
}
