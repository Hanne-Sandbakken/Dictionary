using dictionary.Data;

namespace dictionary.Contracts
{
    public interface IWordClassRepository : IGenericRepository<WordClass> 
    { 
        Task<WordClass> GetDetails(int id);
    }
}
