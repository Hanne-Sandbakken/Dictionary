using dictionary.Data;

namespace dictionary.Contracts
{
    public interface IProjectsRepository
    {
        Task<Project> GetDetails(int id);
    }
}
