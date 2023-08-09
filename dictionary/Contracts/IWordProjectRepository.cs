using dictionary.Data;

namespace dictionary.Contracts
{
    public interface IWordProjectRepository : IGenericRepository<WordProject>
    {
        Task<WordProject> GetDetails(int id);
    }
}
