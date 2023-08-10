using dictionary.Contracts;
using dictionary.Data;
using Microsoft.EntityFrameworkCore;

namespace dictionary.Repository
{
    public class WordsRepository : GenericRepository<Word>, IWordsRepository
    {
        private readonly IWordRepositoy _context;

        public WordsRepository(IWordRepositoy context) : base(context)
        {
            _context = context;
        }

        public async Task<Word> GetDetails(int id)
        {
            return await _context.Words
                .Include(query => query.WordClass)
                .FirstOrDefaultAsync(query => query.Id == id);
        }
    }
}
