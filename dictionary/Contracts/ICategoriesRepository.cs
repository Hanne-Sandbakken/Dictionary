using dictionary.Data;

namespace dictionary.Contracts
{
    public interface ICategoriesRepository : IGenericRepository<Category> 
    { 
        Task<Category> GetDetails(int id);
    }
}
