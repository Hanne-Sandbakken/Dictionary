using dictionary.Contracts;
using dictionary.Data;

namespace dictionary.Repository
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(DictionaryDbContext context) : base(context)
        {
        }
    }
}
