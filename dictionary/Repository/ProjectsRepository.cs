using dictionary.Contracts;
using dictionary.Data;
using Microsoft.EntityFrameworkCore;

namespace dictionary.Repository
{
    public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
    {
        private readonly DictionaryDbContext _context;

        public ProjectsRepository(DictionaryDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Project> GetDetails(int id)
        {
            return await _context.Projects
                .Include(p => p.WordProjects)
                .ThenInclude(wp => wp.Word)
                .ThenInclude(w => w.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
