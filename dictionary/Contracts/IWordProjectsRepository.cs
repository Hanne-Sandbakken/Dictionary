using dictionary.Data;

namespace dictionary.Contracts
{
    public interface IWordProjectsRepository : IGenericRepository<WordProject>
    {
        Task<WordProject> GetDetails(int id);
    }
}
